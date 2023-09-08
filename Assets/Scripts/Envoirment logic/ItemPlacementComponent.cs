using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacementComponent : MonoBehaviour, IInteractable
{
    public float exclusiveTime { get; set; }

    [SerializeField] string placeItemName;
    [SerializeField] BoolVariable isHoldingItem;
    [SerializeField] BoolVariable itemPlaceBool;
    [SerializeField] PastObjectPacketVariable heldItem;
    [SerializeField] GameObject displayItem;


    public void Interact()
    {
        if (heldItem.Value.data.name != placeItemName || !isHoldingItem.value)
            return;

        displayItem.SetActive(true);
        isHoldingItem.value = false;
        HoldItemManager.instance.ShelveItem();
        InventoryManager.Instance.RemoveFromInventory(heldItem.Value);
        itemPlaceBool.value = true;

        ItemPlacementManager.instance.PlaceItem();

        gameObject.layer = 0;
        GetComponent<Light>().enabled = false;
    }

    public string GetInteractionText()
    {
        if (isHoldingItem.value)
        {
            if (placeItemName == heldItem.Value.data.name)
                return "Place item";
            else
                return "Can't place this here";
        }
        else
        {
            return "The " + placeItemName + "'s spot";
        }
    }

    public bool InteractionAllowed()
    {
        return isHoldingItem.value;
    }
}
