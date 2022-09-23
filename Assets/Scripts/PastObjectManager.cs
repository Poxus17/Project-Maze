using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class PastObjectManager : MonoBehaviour
{
    AudioSource audioSource;

    public string text { get; }

    public static PastObjectManager instance;
    void Awake()
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

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact(PastObjectPacket packet)
    {
        audioSource.clip = packet.data.clip;
        audioSource.Play();

        WorldEventDispatcher.instance.BroadcastInteraction.Invoke(packet);
        InventoryManager.Instance.StoreToInventory(packet);
    }


}

