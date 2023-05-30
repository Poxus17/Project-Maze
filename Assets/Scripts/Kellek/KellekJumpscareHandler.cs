using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KellekJumpscareHandler : MonoBehaviour
{
    [Header("Jumpscare type ranges")]
    [SerializeField] float normalRange; // Distance to play normal animation
    [SerializeField] float meleeRange; // Distance to play melee animation
    [SerializeField] float cornerMeleeRange; // Range for Wall melee when caught in corner

    [Space(5)]
    [Header("Jumpscare Events")]
    [SerializeField] GameEvent normalEvent;

    [Space(5)]
    [Header("Object variables")]
    [SerializeField] FloatVariable playerDistanceSqr;
    [SerializeField] FloatVariable timeSinceLastSteeringTarget;

    [Space(5)]
    [Header("Settings")]
    [SerializeField] float requiredTimeSinceSteeringTarget;

    float normalRangeSqr;
    float meleeRangeSqr;
    float cornerRangeSqr;

    private void Start()
    {
        normalRangeSqr = normalRange * normalRange;
        meleeRangeSqr = meleeRange * meleeRange;
        cornerRangeSqr = cornerMeleeRange * cornerMeleeRange;
        AiSightController.OnSeeTarget += OnSeePlayer; //fuck that
    }


    private void Update()
    {
        
    }

    public void OnSeePlayer()
    {
        if (playerDistanceSqr.value > normalRangeSqr)
            return;

        if (timeSinceLastSteeringTarget.value >= requiredTimeSinceSteeringTarget)
        {
            normalEvent.Raise();
        }
    }
}
