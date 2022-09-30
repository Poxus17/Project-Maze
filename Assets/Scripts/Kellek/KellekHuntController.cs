using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KellekHuntController : MainAiController
{
    [SerializeField] AiSightController sightController;

    States state;

    // Start is called before the first frame update
    void Start()
    {
        state = States.Prowl;
    }

    public void GoToPlayer()
    {
        controller.MoveTo(player.transform.position);
    }
}

/// <summary>
/// <para>Prowl - roam around and listen for audio</para>
/// <para>Hunt - Go to last recieved stimuly</para>
/// <para>Chase - Run for your life</para>
/// </summary>
enum States { Prowl, Hunt, Chase }

