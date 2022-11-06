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
    public BoolEvent OnChase;
    [Space(5)]

    [Header("Settings")]
    [SerializeField] float blindChaceTimeMax;
    [SerializeField] float blindChaceTimeMin;
    [SerializeField] float disengageRange;
    [Space(5)]

    [Header("Spawn")]
    public float _minSpawnTime = 1;
    public float _maxSpawnTime = 30;

    States state;

    Vector3 lastRoam = Vector3.zero;
    Vector3 lastHeardAt;

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

        Invoke("RoamNextPoint", 0.2f);
    }

    //0 - Spawn in the ring
    public void SpawnIn()
    {
        Vector3 SpawnPoint = roamManager.FindFarthestPoint();
        parentObject.transform.position = SpawnPoint;
        lastRoam = SpawnPoint;
        parentObject.SetActive(true);

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
        Debug.Log("Roam next");
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
                state = States.Hunt;
            }
            controller.SwitchToPlayer();
        }
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
        {
            state = States.Chase;
            controller.SetChaseSpeed(true);
            StartCoroutine(ChaseTimer());
            SetActiveChase();
            MusicMan.instance.PlaySE(detectSE);
            Debug.Log("Start Chase");
        }
        
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
        disengage = true;
        RoamAway();

        var playerKellekDistacne = Vector3.Distance(transform.position, CentralAI.Instance.player.transform.position);
        while (playerKellekDistacne < disengageRange)
        {
            yield return null;
            playerKellekDistacne = Vector3.Distance(transform.position, CentralAI.Instance.player.transform.position);
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
            CentralAI.Instance.ShakeoffConfirmed();
        }

        parentObject.SetActive(false);
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
}

/// <summary>
/// <para>Prowl - roam around and listen for audio</para>
/// <para>Hunt - Go to last recieved stimuly</para>
/// <para>Chase - Run for your life</para>
/// </summary>
enum States { Prowl, Hunt, Chase }

