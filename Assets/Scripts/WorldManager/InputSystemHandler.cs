using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemHandler : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    public static InputSystemHandler instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SetUIMode(bool active)
    {
        var map = active ? "UI" : "Player";
        playerInput.SwitchCurrentActionMap(map);

        Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = active;
    }
}
