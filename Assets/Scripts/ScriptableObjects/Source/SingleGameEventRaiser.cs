using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGameEventRaiser : MonoBehaviour
{
    [SerializeField] GameEvent raiseEvent;

    public void RaiseEvent(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(context.started)
            raiseEvent.Raise();
    }
}
