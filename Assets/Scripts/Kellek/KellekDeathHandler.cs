using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KellekDeathHandler : MonoBehaviour
{
    //[SerializeField] UnityEvent deathEvent;

    [SerializeField] GameEvent initiateDeath;
    [SerializeField] float JumpscareDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            initiateDeath.Raise();
        }

    }
}
