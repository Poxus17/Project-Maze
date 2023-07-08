using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class PastObjectManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] PastObjectPacketVariable InspectionPacket;
    [SerializeField] GameEvent EnterInspection;
    [SerializeField] FloatVariable itemCount;

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
#if UNITY_EDITOR
        itemCount.value = 0;
#endif
        audioSource = GetComponent<AudioSource>();

    }

    public void Interact(PastObjectPacket packet)
    {
        itemCount.value++;

        audioSource.clip = packet.data.clip;
        audioSource.Play();

        EnterInspection.Raise();
        /*WorldEventDispatcher.instance.BroadcastInteraction.Invoke(packet);*/
        InventoryManager.Instance.StoreToInventory(packet);
    }


}

