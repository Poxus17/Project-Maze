using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacementComponent : MonoBehaviour, IInteractable
{
    public float exclusiveTime { get; set; }

    [SerializeField] string placeItemName;
    [SerializeField] BoolVariable isHoldingItem;
    [SerializeField] BoolVariable itemPlaceBool;
    [SerializeField] PastObjectData heldItem;
    [SerializeField] GameObject displayItem;


    public void Interact()
    {
        if (heldItem.name != placeItemName || !isHoldingItem.value)
            return;

        SetSlotActive();
        HoldItemManager.instance.ShelveItem();
        PastObjectManager.instance.PlaceItem(heldItem.name);
    }

    public string GetInteractionText()
    {
        if (isHoldingItem.value)
        {
            if (placeItemName == heldItem.name)
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

    private void SetSlotActive()
    {
        displayItem.SetActive(true);
        isHoldingItem.value = false;
        
        //InventoryManager.Instance.RemoveFromInventory(heldItem.Value);
        itemPlaceBool.value = true;

        ItemPlacementManager.instance.PlaceItem();

        gameObject.layer = 0;
        GetComponent<Light>().enabled = false;
    }

    public void MatchSlotToMemory(List<string> names)
    {
        if (names.Contains(placeItemName))
            SetSlotActive();
    }
}
