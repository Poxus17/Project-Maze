using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider))]
[ExecuteInEditMode]
public class ObjectInteractionComponent : MonoBehaviour, IInteractable
{
    public float exclusiveTime { get; set; }
    [SerializeField] PastObjectData data;
    [SerializeField] GameEvent inspectionExitEvent;

    void Start()
    {
        gameObject.layer = 6;
    }

    public void Interact()
    {
        PastObjectManager.instance.Interact(data);

        UIManager.Instance.LaunchUIComponent(0);

        if(inspectionExitEvent != null)
            UIManager.Instance.BindGameEventToExit(inspectionExitEvent);

        Banish();
    }

    private void Banish()
    {
        //Send it to FUCKING HELL never to be seen again
        transform.position = new Vector3(0, -100, 0);
    }

    public string GetInteractionText()
    {
        return "Take";
    }

    public bool InteractionAllowed()
    {
        return true;
    }

    public void SetItemObjectState(List<string> takenItems)
    {
        if (takenItems.Contains(data.name))
        {
            Banish();
        }
    }
}


