using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class PastObjectManager : MonoBehaviour, IInteractable, IDataOwner
{
    [SerializeField] PastObjectData pastObjectData;

    AudioSource audioSource;
    PastObjectPacket objectPacket;

    public string text { get; }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        audioSource.clip = pastObjectData.clip;
        audioSource.Play();

        objectPacket = new PastObjectPacket(pastObjectData.transcript, GetComponent<MeshFilter>().mesh, GetComponent<MeshRenderer>().materials);
        WorldEventDispatcher.instance.BroadcastInteraction.Invoke(objectPacket);
    }
}

public class PastObjectPacket
{
    public string text { get; protected set; }
    public Mesh mesh { get; protected set; }
    public Material[] mats { get; protected set; }

    public PastObjectPacket(string t, Mesh m, Material[] ms)
    {
        this.text = t;
        this.mesh = m;
        this.mats = ms;
    }
}

