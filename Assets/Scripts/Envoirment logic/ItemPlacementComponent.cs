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
    [SerializeField] AudioClip placeSound;


    public void Interact()
    {
        if (heldItem.name != placeItemName || !isHoldingItem.value)
            return;

        SetSlotActive();
        HoldItemManager.instance.ShelveItem();
        PastObjectManager.instance.PlaceItem(heldItem.name);
        SaveManager.instance.SaveGame(); //add something to account for chain placements
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

        if(!SaveManager.instance.isLoading)
            MusicMan.instance.PlaySE(placeSound);

        Debug.Log(SaveManager.instance.isLoading);
    }

    public void MatchSlotToMemory(List<string> names)
    {
        if (names.Contains(placeItemName))
            SetSlotActive();
    }
}
