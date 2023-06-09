using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KellekJumpscarePosition : MonoBehaviour
{

    [SerializeField] Vector3 faceOffset;

    private void Start()
    {
        var playerPos = CentralAI.Instance.player.transform.position;
        var correctedPos = playerPos;
        correctedPos.y = transform.position.y;
        transform.rotation = Quaternion.LookRotation(correctedPos - transform.position) * Quaternion.Euler(faceOffset);

        transform.position = correctedPos - (transform.forward * 15);

    }
}
