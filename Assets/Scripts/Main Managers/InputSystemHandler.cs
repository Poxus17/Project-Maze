using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
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

    void Start(){

    }

    public void SetUIMode(bool active)
    {
        var map = active ? "UI" : "Player";
        playerInput.SwitchCurrentActionMap(map);

        Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = active;
    }

    public void SetInputActive(bool active)
    {
        if (active)
            playerInput.ActivateInput();
        else
            playerInput.DeactivateInput();
    }
}
