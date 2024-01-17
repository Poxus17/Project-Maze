using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionTrigger : BaseTrigger
{
    [Space(10), Header("Collision Settings"), Space(5)]
    [SerializeField] string targetTag = ""; //tag of target to collide with.

    void OnTriggerEnter(Collider other)
    {
        if(targetTag == "") Trigger();
        else if(other.gameObject.tag == targetTag) Trigger();
    }
}
