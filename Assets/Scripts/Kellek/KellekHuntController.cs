using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


public class KellekHuntController : MainAiController
{
    [Header("AI Components")]
    [SerializeField] AiSightController sightController;
    [SerializeField] AiRoamManager roamManager;
    [Space(5)]

    [Header("Music Components")]
    [SerializeField] AudioClip detectSE;
    [SerializeField] AudioClip stepAway;
    [SerializeField] AudioClip[] detectionLaughs;
    [SerializeField] AudioSource laughAudioSource;
    public BoolEvent OnChase;
    [Space(5)]

    [Header("Settings")]
    [SerializeField] float blindChaceTimeMax;
    [SerializeField] float blindChaceTimeMin;
    [SerializeField] float minimalChaseTime;
    [SerializeField] float stepAwayEffectRange;
    [SerializeField] float chaseWaitTime;
    [SerializeField] Renderer renderer;
    [Space(5)]

    [Header("Spawn")]
    public bool instantSpawn;
    public float _minSpawnTime = 1;
    public float _maxSpawnTime = 30;
    public float _minDespawnTime = 30;
    public float _maxDespawnTime = 120;
    [Space(5)]

    [Header("Variable Assets")]
    [SerializeField] BoolVariable chaseLock;
    [SerializeField] FloatVariable itemCount;
    [SerializeField] BoolVariable playerIsHiding;

    States state;

    Vector3 lastRoam = Vector3.zero;
    Vector3 lastHeardAt;
    Vector3 lastSeenAt;
    Vector3 oblivion = new Vector3(-10000, -10000, -10000);

    private bool disengage = false;
    private bool queueShakeoff = false;
    private bool blindChasing = false;
    private bool despawnDisrupted;
    private int blindChaseCallsCounter = 0;

    //Suspension parameter
    bool suspended;

    public GameObject parentObject { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        state = States.OffMap;
        parentObject = gameObject.transform.parent.gameObject;
        AiMovementController.OnArrivedAtDestination += DestinationArrived;
        AiListenerController.OnNoticeNoise += ChaseNoise;
        AiSightController.OnSeeTarget += FoundYou;

        //Invoke("RoamNextPoint", 0.2f);
    }

    //0 - Spawn in the ring
    public void SpawnIn()
    {
        if (itemCount.value < 2)
            return;

        //roamManager.LoadRoamData(1, 1);
        Vector3 SpawnPoint = roamManager.FindFarthestPoint();
        controller.Teleport(new Vector3(SpawnPoint.x, 6, SpawnPoint.z));
        lastRoam = SpawnPoint;
        state = States.Prowl;
        disengage = false;
        despawnDisrupted = false;

        RoamNextPoint();
        GlobalTimerManager.instance.RegisterForTimer(
            () => { if(!despawnDisrupted) StartCoroutine(LeaveAudibleArea()); }, 
            Random.Range(_minSpawnTime, _maxSpawnTime)
            );
    }
    /*
     * |
     * |
     * V
     * 
     * 1 - Roam to random point
     */
    void RoamNextPoint()
    {
        //Debug.Log("Roam next");
        lastHeardAt = Vector3.zero;
        lastRoam = roamManager.GetRoamPoint(lastRoam);
        controller.MoveTo(lastRoam);
    }
    /*
     * |
     * |
     * V
     * 
     * 2 - Arrive to target position hub
     */
    void DestinationArrived()
    {
        if (state == States.Prowl)
        {
            if (disengage)
                RoamAway();
            else
                RoamNextPoint();
        }
        else if (state == States.Hunt)
        {
            state = States.Prowl;
            RoamNextPoint();
        }
        else if (state == States.Chase)
        {
            if (blindChasing)
                FindBlindTarget();
            else
                InitBlindChase();
        }
    }
    /*
     * He finds a noise
     * 
     * |
     * |
     * V
     * 
     * 3 - Start going after noise
     */
    void ChaseNoise()
    {
        if (!disengage)
        {
            if (state != States.Chase)
            {
                if (state != States.Hunt)
                    PlayDetectionLaugh();
                state = States.Hunt;
            }
            GoToPlayer();
            if (state == States.Chase)
                Debug.Log("Mid chase switch");
        }
    }
    
    void PlayDetectionLaugh()
    {
        var randomClip = detectionLaughs[Random.Range(0, detectionLaughs.Length)];
        MusicMan.instance.PlaySEWithReverb(randomClip, Vector3.Distance(transform.position, CentralAI.Instance.player.transform.position));
    }

    public void GoToPlayer()
    {
        blindChasing = false;
        controller.SwitchToPlayer();
    }

    /*
     * He has line of sight
     * 
     * |
     * |
     * V
     * 
     * 4 - starting to chase
     */
    void FoundYou()
    {
        if(playerIsHiding.value)
            return;

        despawnDisrupted = true;

        if (state == States.Chase){
            controller.SwitchToPlayer();
            Debug.Log("Mid chase switch");
        }
        else
        {
            state = States.Chase;
            chaseLock.value = true;
            MusicMan.instance.PlaySE(detectSE, 1f);
            controller.CancelMovement();

            GlobalTimerManager.instance.RegisterForTimer(HereICome, chaseWaitTime);
        }
    }
    
    void HereICome()
    {
        controller.SetChaseSpeed(true);
        OnChase.Invoke(true);
    }
    /*
     * Lost eyesight
     * 
     * |
     * |
     * V
     * 5 - Countdown to cancel chase
     */
     void InitBlindChase(){
        blindChasing = true;
        blindChaseCallsCounter++;
        FindBlindTarget();

        var random = Random.Range(blindChaceTimeMin, blindChaceTimeMax);
        GlobalTimerManager.instance.RegisterForTimer(CheckEndBlindChase, random);
     }

     void FindBlindTarget(){
        var blindTarget = FindRoute();

        if(blindTarget == Vector3.zero)
            StopChase();

        controller.MoveTo(blindTarget);
     }

     void CheckEndBlindChase(){
        blindChaseCallsCounter--;
        if(blindChasing && blindChaseCallsCounter <= 0){
            blindChasing = false;
            StopChase();
            return;
        }
     }
    /*IEnumerator BlindChaseTimer()
    {
        
        yield return new WaitForSeconds(random);
        StopChase();
        blindChasing = false;
    }*/

    /* Sight not replenished
     * 
     * |
     * |
     * V
     * 
     * 6 - Quit chase, commense shake off
     */
    void StopChase()
    {
        controller.SetChaseSpeed(false);

        state = States.Prowl; // Add here something to check if he still has a hearing target

        chaseLock.value = false;
        OnChase.Invoke(false);
        StartCoroutine(LeaveAudibleArea());
        Debug.Log("quit chase");
    }

    IEnumerator LeaveAudibleArea()
    {
        state = States.OffMap;

        if (renderer.isVisible)
        {
            RoamAway();
            while (renderer.isVisible)
                yield return null;
        }

        Shakeoff();

        if(Vector3.Distance(transform.position, CentralAI.Instance.player.transform.position) < stepAwayEffectRange)
            MusicMan.instance.PlayLocalSE(stepAway, transform.position);
    }

    void RoamAway()
    {
        controller.MoveTo(roamManager.FindFarthestPoint());
    }

    void Shakeoff()
    {
        /*if(queueShakeoff)
        {
            queueShakeoff = false;
        }*/

        controller.SetStop(true);
        controller.Teleport(oblivion);
        CentralAI.Instance.ShakeoffConfirmed();
    }
    

    /*
     * 7 - Outside Input
     */

    // Recive request to shakeoff, either confirm or queue for the end of the chase
    public void RequestShakeoff()
    {
        if (state == States.OffMap)
            Shakeoff();
        else if (state != States.Chase)
        {
            StartCoroutine(LeaveAudibleArea());
        }
        else
        {
            queueShakeoff = true;
        }
    }

    public void TurnOff()
    {
        if (state == States.OffMap)
            return;

        suspended = true;
        controller.SavePosition();
        controller.Teleport(oblivion);
    }
    public void TurnOn() //wink wink
    {
        if (!suspended || SectionsManager.instance.currentSection == 0)
            return;

        controller.RestorePosition();

        switch(state)
        {
            case States.Prowl:
                controller.MoveTo(lastRoam);
                break;
            case States.Hunt:
                controller.SwitchToPlayer();
                break;
            default:
                SpawnIn();
                break;

        }
        
    }

    private void OnDestroy()
    {
        AiMovementController.OnArrivedAtDestination -= DestinationArrived;
        AiListenerController.OnNoticeNoise -= ChaseNoise;
        AiSightController.OnSeeTarget -= FoundYou;
    }

    
    [SerializeField] float forwardTargetClearDistance = 30;
    [SerializeField] float wallDetectionThreshold = 5;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject markerPrefab;
    private GameObject targetMarker;

    public Vector3 FindRoute(){
        RaycastHit hit; 

        targetMarker = Instantiate(markerPrefab);
        if(Physics.Raycast(transform.position, transform.forward, out hit, 100f, layerMask)){

            var dir = transform.forward;
            var checkpoint = hit.point - dir * 2.5f;
            Debug.DrawLine(transform.position, hit.point, Color.red, 60f);
            
            if(hit.distance > forwardTargetClearDistance)
            {
                var toReturn = transform.position + (transform.forward * forwardTargetClearDistance);
                targetMarker.transform.position = toReturn;
                return toReturn;
            } 
            else
                return FindNewRoute(checkpoint);
        }

        else return Vector3.zero;
    }

    public Vector3 FindNewRoute(Vector3 checkpoint){

        RaycastHit checkFirst;

        bool rightFirst = Random.Range(0, 2) == 0;
        var firstDir = rightFirst ? transform.right : -transform.right;

        if(Physics.Raycast(checkpoint, firstDir, out checkFirst, 100f, layerMask)){
            if(checkFirst.distance > wallDetectionThreshold){
                var toReturn = checkpoint + transform.right * (checkFirst.distance > forwardTargetClearDistance ? forwardTargetClearDistance : checkFirst.distance - 2);
                targetMarker.transform.position = toReturn;
                return toReturn;
            }
        }
        
        var secondDir = rightFirst ? -transform.right : transform.right;
        RaycastHit checkSecond;
        if(Physics.Raycast(checkpoint, secondDir, out checkSecond, 100f, layerMask)){
            if(checkSecond.distance > wallDetectionThreshold){
                var toReturn = checkpoint - transform.right * (checkSecond.distance > forwardTargetClearDistance ? forwardTargetClearDistance : checkSecond.distance - 2);
                targetMarker.transform.position = toReturn;
                return toReturn;
            }
        }

        return Vector3.zero;
    }
}

/// <summary>
/// <para>Prowl - roam around and listen for audio</para>
/// <para>Hunt - Go to last recieved stimuly</para>
/// <para>Chase - Run for your life</para>
/// </summary>
enum States { OffMap, Prowl, Hunt, Chase }

