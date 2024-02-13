using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableComponent : MonoBehaviour, IInteractable
{
    [SerializeField] string intreactionText;
    [SerializeField] float _exclusiveTime;
    [SerializeField] bool consumeInteraction = false;
    [SerializeField] UnityEvent Interaction;
    [SerializeField] BoolVariable interactionCondition;
    [SerializeField] bool notCondition;
    [SerializeField] UnityEvent failInteraction;
    
    

    public float exclusiveTime { get; set; }

    void Start()
    {
        exclusiveTime = _exclusiveTime;
    }

    public void Interact()
    {
        if(!InteractionAllowed()){
            failInteraction.Invoke();
            Debug.Log(!notCondition);
            Debug.Log((interactionCondition.value && !notCondition));
            Debug.Log((interactionCondition.value && (!notCondition)));
            return;
        }
            

        Interaction.Invoke();

        if(consumeInteraction)
            gameObject.tag = "Untagged";
    }

    public string GetInteractionText()
    {
        return intreactionText;
    }

    public bool InteractionAllowed()
    {
        return (interactionCondition == null) ? true : !(interactionCondition.value ^ !notCondition);
    }
}
