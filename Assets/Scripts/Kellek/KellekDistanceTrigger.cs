using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KellekDistanceTrigger : MonoBehaviour
{
    [SerializeField] FloatVariable playerDistanceSqr;
    [SerializeField] float triggerRange;
    [SerializeField] bool consumable;
    [SerializeField] UnityEngine.Events.UnityEvent onPlayerInRange;


    void Update()
    {
        if (playerDistanceSqr.value < triggerRange * triggerRange)
        {
            onPlayerInRange.Invoke();

            if(consumable)
                gameObject.SetActive(false);
        }
    }
}
