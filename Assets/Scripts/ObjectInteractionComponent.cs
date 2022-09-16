using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(BoxCollider))]
[ExecuteInEditMode]
public class ObjectInteractionComponent : MonoBehaviour, IInteractable
{

    [SerializeField] PastObjectData data;

    void Awake()
    {
        GetComponent<MeshFilter>().mesh = data.mesh;
        GetComponent<MeshRenderer>().materials = data.materials;
        GetComponent<BoxCollider>().size = data.colliderSize;
        transform.localScale = data.scale;
        gameObject.layer = 6;
    }

    public void Interact()
    {
        PastObjectManager.instance.Interact(data);
        Destroy(gameObject);
    }
}
