using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BringUpCompass : MonoBehaviour
{
    [SerializeField] Vector3 downPos;
    [SerializeField] Vector3 upPos;
    [SerializeField] BoolVariable compassUp;

    private void Start()
    {
        compassUp.value = false;
    }

    public void UseCompass(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            compassUp.value = !compassUp.value;

            transform.localPosition = compassUp.value ? upPos : downPos;
        }
    }
}
