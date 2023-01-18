using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class KellekHuntController : MainAiController
{
    [Header("AI Components")]
    [SerializeField] AiSightController sightController;
    [SerializeField] AiRoamManager roamManager;
    [Space(5)]

    [Header("Music Components")]
    [SerializeField] AudioClip detectSE;
    [SerializeField] AudioClip[] detectionLaughs;
    [SerializeField] AudioSource laughAudioSource;
    public BoolEvent OnChase;
    [Space(5)]

    [Header("Settings")]
    [SerializeField] float blindChaceTimeMax;
    [SerializeField] float blindChaceTimeMin;
    [SerializeField] float disengageRange;
    [SerializeField] float chaseWaitTime;
    [Space(5)]

    [Header("Spawn")]
    public float _minSpawnTime = 1;
    public float _maxSpawnTime = 30;

    States state;

    Vector3 lastRoam = Vector3.zero;
    Vector3 lastHeardAt;
    Vector3 oblivion = new Vector3(-10000, -10000, -10000);

    bool disengage = false;
    bool queueShakeoff= false;

    public GameObject parentObject { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        state = States.Prowl;
        parentObject = gameObject.transform.parent.gameObject;
        AiMovementController.OnArrivedAtDestination += DestinationArrived;
        AiListenerController.OnNoticeNoise += ChaseNoise;
        AiSightController.OnSeeTarget += FoundYou;

        //Invoke("RoamNextPoint", 0.2f);
    }

    //0 - Spawn in the ring
    public void SpawnIn()
    {
        //roamManager.LoadRoamData(1, 1);
        Vector3 SpawnPoint = roamManager.FindFarthestPoint();
        controller.Teleport(new Vector3(SpawnPoint.x, 6, SpawnPoint.z));
        lastRoam = SpawnPoint;
        state = States.Prowl;
        disengage = false;

        RoamNextPoint();
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
            StopChase();
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
            controller.SwitchToPlayer();
        }
    }
    
    void PlayDetectionLaugh()
    {
        var randomClip = detectionLaughs[Random.Range(0, detectionLaughs.Length)];
        laughAudioSource.clip = randomClip;
        laughAudioSource.Play();
    }

    public void GoToPlayer()
    {
        controller.MoveTo(CentralAI.Instance.player.transform.position);
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
        if(state == States.Chase)
            controller.SwitchToPlayer();
        else
            StartCoroutine(IllGiveYouToTheCountOf());
    }

    IEnumerator IllGiveYouToTheCountOf()
    {
        state = States.Chase;
        MusicMan.instance.PlaySE(detectSE, 1f);
        controller.CancelMovement();
        yield return new WaitForSeconds(chaseWaitTime);

        //Ready or not
        HereICome();
    }
    void HereICome()
    {
        controller.SetChaseSpeed(true);
        StartCoroutine(ChaseTimer());
        SetActiveChase();
        Debug.Log("Start Chase");
    }
    void SetActiveChase()
    {
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
    IEnumerator ChaseTimer()
    {
        yield return new WaitForSeconds(Random.Range(blindChaceTimeMin, blindChaceTimeMax));
        StopChase();
    }
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

        OnChase.Invoke(false);
        StartCoroutine(LeaveAudibleArea());
        Debug.Log("quit chase");
    }

    IEnumerator LeaveAudibleArea()
    {
        var playerKellekDistacne = Vector3.Distance(transform.position, CentralAI.Instance.player.transform.position);

        if(playerKellekDistacne < disengageRange)
        {
            disengage = true;
            RoamAway();

            while (playerKellekDistacne < disengageRange)
            {
                yield return null;
                playerKellekDistacne = Vector3.Distance(transform.position, CentralAI.Instance.player.transform.position);
            }
        }
        Shakeoff();
    }

    void RoamAway()
    {
        controller.MoveTo(roamManager.FindFarthestPoint());
    }

    void Shakeoff()
    {
        if(queueShakeoff)
        {
            queueShakeoff = false;
        }

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
        if(state != States.Chase)
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
        controller.Teleport(oblivion);
    }
    public void TurnOn()
    {
        if (SectionsManager.instance.currentSection != 0)
            SpawnIn();
    }

    private void OnDestroy()
    {
        AiMovementController.OnArrivedAtDestination -= DestinationArrived;
        AiListenerController.OnNoticeNoise -= ChaseNoise;
        AiSightController.OnSeeTarget -= FoundYou;
    }
}

/// <summary>
/// <para>Prowl - roam around and listen for audio</para>
/// <para>Hunt - Go to last recieved stimuly</para>
/// <para>Chase - Run for your life</para>
/// </summary>
enum States { Prowl, Hunt, Chase }

