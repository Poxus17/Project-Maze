using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTeleport : MonoBehaviour
{
    [SerializeField] float deltaY;

    public void ElevatorTeleportation()
    {
        var pos = transform.position;
        pos.y += deltaY;
        transform.position = pos;
    }
}
