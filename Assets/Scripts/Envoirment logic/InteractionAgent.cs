using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAgent : MonoBehaviour
{
    private LayerMask defaultLayerMask;
    private string defaultTag;

    private void Start(){
        defaultLayerMask = gameObject.layer;
        defaultTag = gameObject.tag;
    }

    public void SetInteractionVisible(bool visible){
        gameObject.layer = visible ? defaultLayerMask : 0;
    }

    public void SetInteractable(bool interactable){
        gameObject.tag = interactable ? defaultTag : "Untagged";
    }
}
