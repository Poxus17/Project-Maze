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

    States state;

    Vector3 lastRoam = Vector3.zero;
    Vector3 lastHeardAt;

    // Start is called before the first frame update
    void Start()
    {
        state = States.Prowl;
        AiMovementController.OnArrivedAtDestination += DestinationArrived;
        AiListenerController.OnNoticeNoise += ChaseNoise;
        AiSightController.OnSeeTarget += FoundYou;

        Invoke("RoamNextPoint", 0.2f);
    }

    public void GoToPlayer()
    {
        controller.MoveTo(CentralAI.Instance.player.transform.position);
    }

    void DestinationArrived()
    {
        if (state == States.Prowl)
        {
            RoamNextPoint();
        }
        else if(state == States.Hunt)
        {
            state = States.Prowl;
            RoamNextPoint();
        }
        else if(state == States.Chase)
        {
            StopChase();
        }
    }

    void RoamNextPoint()
    {
        lastHeardAt = Vector3.zero;
        lastRoam = roamManager.GetRoamPoint(lastRoam);
        controller.MoveTo(lastRoam);
    }

    void ChaseNoise()
    {
        if(state != States.Chase)
        {
            state = States.Hunt;
        }
        controller.SwitchToPlayer();
    }

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

    IEnumerator ChaseTimer()
    {
        yield return new WaitForSeconds(Random.Range(blindChaceTimeMin, blindChaceTimeMax));
        StopChase();
    }

    void StopChase()
    {
        controller.SetChaseSpeed(false);

        state = States.Prowl;

        OnChase.Invoke(false);
        Debug.Log("quit chase");
    }

    void SetActiveChase()
    {
        OnChase.Invoke(true);
    }
}

/// <summary>
/// <para>Prowl - roam around and listen for audio</para>
/// <para>Hunt - Go to last recieved stimuly</para>
/// <para>Chase - Run for your life</para>
/// </summary>
enum States { Prowl, Hunt, Chase }

