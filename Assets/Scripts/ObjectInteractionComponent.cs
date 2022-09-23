using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[ExecuteInEditMode]
public class ObjectInteractionComponent : MonoBehaviour, IInteractable
{
    [SerializeField] PastObjectData data;


    PastObjectPacket pastObjectPacket;
    void Awake()
    {
        gameObject.layer = 6;

        pastObjectPacket = new PastObjectPacket(data, gameObject);
    }

    public void Interact()
    {
        PastObjectManager.instance.Interact(pastObjectPacket);

        //Send it to FUCKING HELL never to be seen again
        transform.position = new Vector3(-1000, -1000, -1000);
    }
}

public class PastObjectPacket
{
    public PastObjectData data { get; protected set; }
    public GameObject gameObject { get; protected set; }
    public Vector3 scale { get; protected set; }
    public Vector3 eularRotation { get; protected set; }

    public PastObjectPacket(PastObjectData pastObject, GameObject gameObject)
    {
        this.data = pastObject;
        this.gameObject = gameObject;
        this.scale = gameObject.transform.localScale;
        this.eularRotation = gameObject.transform.localEulerAngles;
    }
}
