using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldEventDispatcher : MonoBehaviour
{

    public PastObjectEvent BroadcastInteraction;

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

}

[System.Serializable]
public class PastObjectEvent : UnityEvent<PastObjectPacket> { }