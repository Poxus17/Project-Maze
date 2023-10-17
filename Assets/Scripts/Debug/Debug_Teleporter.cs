using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Teleporter : MonoBehaviour
{
    [SerializeField] Vector3 teleportTarget;

    Vector3 lastPos;
    bool isTeleported = false;

    public void Teleport()
    {
        lastPos = gameObject.transform.position;
        gameObject.transform.position = teleportTarget;
    }

    public void Return()
    {
        gameObject.transform.position = lastPos;
    }

    public void ToggleTeleport()
    {
        if (isTeleported)
            Return();
        else
            Teleport();

        isTeleported = !isTeleported;
    }
}
