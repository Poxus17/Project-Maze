using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BringUpCompass : MonoBehaviour
{
    [SerializeField] Vector3 downPos;
    [SerializeField] Vector3 upPos;
    bool compassUp = false;

    public void UseCompass(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            compassUp = !compassUp;

            transform.localPosition = compassUp ? upPos : downPos;
        }
    }
}
