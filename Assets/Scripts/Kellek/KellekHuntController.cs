using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
    [SerializeField] BoolVariable playerIsCaught;
    [SerializeField] GameEvent initiateDeath;
    [SerializeField] FloatVariable playerDistance; //I don't like this
 
    States state;

    Vector3 lastRoam = Vector3.zero;
    Vector3 lastHeardAt;
    Vector3 lastSeenAt;
    Vector3 oblivion = new Vector3(-10000, -10000, -10000);

    private bool turnedOn = true;
    private bool spawnDisrupted = false;
    private bool disengage = false;
    private bool blindChasing = false;
    private bool despawnDisrupted;
    private int blindChaseCallsCounter = 0;

    //Roam rng limiter
    private float closeDistance = 40f;
    private float playerDistanceLast = 0;
    private int closeRoamCounter = 0;
    private int closeRoamCountThreshold = 3;

    //Suspension parameter
    bool suspended;

    public GameObject parentObject { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        turnedOn = true;
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
        Debug.Log("Kellek spawn requested");
        if (itemCount.value < 2)
        {
            Debug.Log("Item requirement not met for spawn");
            return;
        }
            

        if(!turnedOn){
            spawnDisrupted = true;
            Debug.Log("Kellek spawn was disrupted by UI lock");
            return;
        }

        //roamManager.LoadRoamData(1, 1);
        Vector3 SpawnPoint = roamManager.FindFarthestPoint();
        controller.Teleport(new Vector3(SpawnPoint.x, 6, SpawnPoint.z));
        lastRoam = SpawnPoint;
        state = States.Prowl;
        disengage = false;
        despawnDisrupted = false;

        RoamNextPoint();
        GlobalTimerManager.instance.RegisterForTimer(RequestShakeoff, Random.Range(_minSpawnTime, _maxSpawnTime));
        Debug.Log("Kellek spawned in");
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
        Debug.Log("Kellek arrived at destination. State: " + state);
        if (state == States.Prowl)
        {
            if (disengage)
                RoamAway();
            else if(CheckCloseRoamCap())
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
        var valid = controller.SwitchToPlayer();
        if(!valid)
            StopChase();
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

        if (state == States.Chase){
            controller.SwitchToPlayer();
            Debug.Log("Mid chase switch");
        }
        else
        {
            Debug.Log("Kellek found you");
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

        Debug.Log("Blind chase to " + blindTarget);
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
        Debug.Log("Quit chase");

        if(despawnDisrupted)
            Shakeoff();
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
        Debug.Log("Kellek despawned");
    }
    

    /*
     * 7 - Outside Input
     */

    // Recive request to shakeoff, either confirm or queue for the end of the chase
    public void RequestShakeoff()
    {
        Debug.Log("Kellek despawn requested");
        if (state == States.OffMap)
            Shakeoff();
        else if (state != States.Chase)
        {
            StartCoroutine(LeaveAudibleArea());
        }
        else
        {
            despawnDisrupted = true;
        }
    }

    public void TurnOff()
    {
        Debug.Log("Kellek turned off by UI lock");
        turnedOn = false;
        if (state == States.OffMap)
            return;

        controller.SavePosition();
        controller.Teleport(oblivion);
        
    }
    public void TurnOn() //wink wink
    {
        Debug.Log("UI lock on Kellek was lifted");
        turnedOn = true;
        if (SectionsManager.instance.currentSection == 0)
            return;

        controller.RestorePosition();
        
        if (spawnDisrupted)
        {
            Debug.Log("Restoring disrupted Kellek spawn");
            spawnDisrupted = false;
            SpawnIn();
            return;
        }

        switch(state)
        {
            case States.Prowl:
                controller.MoveTo(lastRoam);
                break;
            case States.Hunt:
                controller.SwitchToPlayer();
                break;
            default:
                break;

        }
        
    }

    private void OnDestroy()
    {
        AiMovementController.OnArrivedAtDestination -= DestinationArrived;
        AiListenerController.OnNoticeNoise -= ChaseNoise;
        AiSightController.OnSeeTarget -= FoundYou;
    }

    public void CustomPlayerCheck(){
        if(state != States.Chase)
            return;

        playerIsCaught.value = sightController.CustomPlayerCheck();

        if(playerIsCaught.value){
            StopChase();
            Shakeoff();
            GlobalTimerManager.instance.RegisterForTimer(() => {initiateDeath.Raise();}, 5f);
        }
    }

    public bool CheckCloseRoamCap(){
        playerDistanceLast = playerDistance.value;
        var sqrCloseDistance = closeDistance * closeDistance;

        if(playerDistance.value < sqrCloseDistance)
        {
            closeRoamCounter++;

            if(closeRoamCounter >= closeRoamCountThreshold)
            {
                closeRoamCounter = 0;
                Debug.Log("Close roam cap reached. Roaming away");
                return true;
            }

            return false;
        }
        else
        {
            closeRoamCounter = 0;
            return false;
        }
            
    }

    #region Realtime navigation

    [Space(10), Header("Realtime navigation settings")]
    [SerializeField] bool placeMarkers = false;
    [SerializeField] float forwardTargetClearDistance = 30;
    [SerializeField] float wallDetectionThreshold = 5;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject markerPrefab;
    private GameObject targetMarker;

    public Vector3 FindRoute(){
        RaycastHit hit; 

        if(placeMarkers)
            targetMarker = Instantiate(markerPrefab);

        if(Physics.Raycast(transform.position, transform.forward, out hit, 100f, layerMask)){

            var dir = transform.forward;
            var checkpoint = hit.point - dir * 2.5f;
            Debug.DrawLine(transform.position, hit.point, Color.red, 60f);
            
            if(hit.distance > forwardTargetClearDistance)
            {
                var toReturn = transform.position + (transform.forward * forwardTargetClearDistance);

                if(placeMarkers)
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
                
                if(placeMarkers)
                    targetMarker.transform.position = toReturn;
                return toReturn;
            }
        }
        
        var secondDir = rightFirst ? -transform.right : transform.right;
        RaycastHit checkSecond;
        if(Physics.Raycast(checkpoint, secondDir, out checkSecond, 100f, layerMask)){
            if(checkSecond.distance > wallDetectionThreshold){
                var toReturn = checkpoint - transform.right * (checkSecond.distance > forwardTargetClearDistance ? forwardTargetClearDistance : checkSecond.distance - 2);
                if(placeMarkers)
                    targetMarker.transform.position = toReturn;
                return toReturn;
            }
        }

        return Vector3.zero;
    }

    #endregion
}

/// <summary>
/// <para>Prowl - roam around and listen for audio</para>
/// <para>Hunt - Go to last recieved stimuly</para>
/// <para>Chase - Run for your life</para>
/// </summary>
enum States { OffMap, Prowl, Hunt, Chase }

