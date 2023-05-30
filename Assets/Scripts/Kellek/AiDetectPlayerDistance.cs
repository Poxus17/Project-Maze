using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDetectPlayerDistance : MonoBehaviour
{
    [SerializeField] FloatVariable distanceToPlayer;
    [SerializeField] Vector3Variable playerTargetVector;

    // Update is called once per frame
    void Update()
    {
        playerTargetVector.value = CentralAI.Instance.player.transform.position - transform.position;
        distanceToPlayer.value = playerTargetVector.value.sqrMagnitude;
    }
}
