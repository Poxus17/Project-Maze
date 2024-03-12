using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemHandler : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    public bool uiMode => playerInput.currentActionMap.name == "UI";

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

    public void ResetMap(){
        playerInput.SwitchCurrentActionMap("Player");
    }

    public void SetInputActive(bool active)
    {
        if (active)
            playerInput.ActivateInput();
        else
            playerInput.DeactivateInput();
    }
}
