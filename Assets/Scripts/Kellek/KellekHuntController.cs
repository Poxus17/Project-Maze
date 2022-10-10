using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KellekHuntController : MainAiController
{
    [SerializeField] AiSightController sightController;
    [SerializeField] AiRoamManager roamManager;

    States state;

    Vector3 lastRoam = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        state = States.Prowl;
        AiMovementController.OnArrivedAtDestination += DestinationArrived;

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
    }

    void RoamNextPoint()
    {
        lastRoam = roamManager.GetRoamPoint(lastRoam);
        controller.MoveTo(lastRoam);
    }

}

/// <summary>
/// <para>Prowl - roam around and listen for audio</para>
/// <para>Hunt - Go to last recieved stimuly</para>
/// <para>Chase - Run for your life</para>
/// </summary>
enum States { Prowl, Hunt, Chase }

