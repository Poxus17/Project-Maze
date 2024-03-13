using UnityEngine;

public class ItemInteractableComponent : MonoBehaviour , IInteractable
{
    public float exclusiveTime { get; set; }

    [SerializeField] string actionItemName;
    [SerializeField] string interactionText;
    [SerializeField, Tooltip("Will disable interaction if not holding the right item")] bool isExclusive;
    [SerializeField] BoolVariable isHoldingItem;
    [SerializeField] PhysicalObject heldItem;
    [SerializeField] TriggerEventPacket eventPacket;

    public void Interact(){
        if(InteractionAllowed())
            eventPacket.Invoke();
    }

    public string GetInteractionText()
    {
        return isHoldingItem.value ? (isExclusive ? (heldItem.name == actionItemName ? interactionText : "") : interactionText) : ""; //I'm gonna throw up
    }

    public bool InteractionAllowed()
    {
        //if exclusive, return if holding the right item, else return if holding any item
        return isHoldingItem.value && (heldItem.name == actionItemName);
    }
}
