using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableComponent : MonoBehaviour, IInteractable
{
    [SerializeField] string intreactionText;
    [SerializeField] float _exclusiveTime;
    [SerializeField] BoolVariable interactionCondition;
    [SerializeField] UnityEvent Interaction;

    public float exclusiveTime { get; set; }

    void Start()
    {
        exclusiveTime = _exclusiveTime;
    }

    public void Interact()
    {
        if(interactionCondition)
            Interaction.Invoke();
    }

    public string GetInteractionText()
    {
        return intreactionText;
    }

    public bool InteractionAllowed()
    {
        return (interactionCondition == null) ? true : interactionCondition.value;
    }

}
