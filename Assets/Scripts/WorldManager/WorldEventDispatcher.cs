using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldEventDispatcher : MonoBehaviour
{

    public PastObjectEvent BroadcastInteraction;
    public BoolEvent BroadcastSprint;
    public BoolEvent BroadcastInventoryActive;


    public static WorldEventDispatcher instance;
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

    public void SetUIActive(bool active)
    {
        Cursor.lockState = active ? CursorLockMode.None: CursorLockMode.Locked;
        Cursor.visible = active;
    }

    public void ShutThemDown()
    {
        CentralAI.Instance.player.SetActive(false);
        CentralAI.Instance.TurnOffAi();
    }
}

[System.Serializable]
public class PastObjectEvent : UnityEvent<PastObjectPacket> { }

[System.Serializable]
public class BoolEvent : UnityEvent<bool> { }