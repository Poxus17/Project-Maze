using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KellekDeathHandler : MonoBehaviour
{
    [SerializeField] UnityEvent deathEvent;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
            deathEvent.Invoke();
    }
}
