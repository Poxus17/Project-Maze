using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDetectPlayerDistance : MonoBehaviour
{
    [SerializeField] FloatVariable distanceToPlayer;
    [SerializeField] Vector3Variable playerTargetVector;

    void Start(){
        CalculateDistance();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
    }

    private void CalculateDistance(){
        var correctedPlayerPosition = new Vector3(CentralAI.Instance.player.transform.position.x, transform.position.y, CentralAI.Instance.player.transform.position.z);
        playerTargetVector.value = correctedPlayerPosition - transform.position;
        distanceToPlayer.value = playerTargetVector.value.sqrMagnitude;
    }
}
