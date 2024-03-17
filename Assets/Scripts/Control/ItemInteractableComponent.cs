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


    /// Invokes the Interaction event if the user is allowed to interact with the game. Does nothing if the interaction is not allowed
    public void Interact(){
        /// Invoke the event packet if interaction is allowed.
        if(!InteractionAllowed())
            return;

        eventPacket.Invoke();
        HoldItemManager.instance.ShelveItem();
        ItemsManager.instance.RemoveItem(heldItem.name);
    }

    /// Gets the text that should be displayed to the user when the user interacts with the item. This is determined by the state of the lock and the lock's exclusive state.
    /// 
    /// 
    /// Returns: 
    /// 	 The text that should be displayed to the user when the lock's exclusive state is changed to true
    public string GetInteractionText()
    {
        return isHoldingItem.value ? (isExclusive ? (heldItem.name == actionItemName ? interactionText : "") : interactionText) : ""; //I'm gonna throw up
    }

    /// Checks if interaction is allowed. This is used to determine if an action can be carried out to the item that is holding it.
    /// 
    /// 
    /// Returns: 
    /// 	 True if the action can be carried out false otherwise. Note that it is possible to interact with an item that is holding it
    public bool InteractionAllowed()
    {
        //if exclusive, return if holding the right item, else return if holding any item
        return isHoldingItem.value && (heldItem.name == actionItemName);
    }
}
