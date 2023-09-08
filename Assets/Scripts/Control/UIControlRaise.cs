using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControlRaise : MonoBehaviour
{
    [SerializeField] int raiseUIIndex;

    public void RaiseUI(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.started)
            UIManager.Instance.LaunchUIComponent(raiseUIIndex);
    }
}
