using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryActions : MonoBehaviour, IInventorySection
{
    [SerializeField] InventorySlot[] slots;
    [SerializeField] PhysicalObject inspectionItem;
    [SerializeField] ItemCategory itemCategory;
    [SerializeField] GameObject holdButton;

    private ValueTransmitter<string> inspectTransmitter;

    public void Launch()
    {
        gameObject.SetActive(true);
        inspectTransmitter = new ValueTransmitter<string>();
        inspectTransmitter.SubscribeOnChange(OnValueChange);
        //inspectTransmitter.SubscribeOnChange(InspectFromInventory);

        foreach(InventorySlot slut in slots){
            slut.Init(inspectTransmitter);
        }

        DisplayInventory();
    }
    public void DisplayInventory()
    {
        ClearSlots();
        int slotIndex = 0;

        List<StoreableItem> inventory = ItemsManager.instance.ExportInventoryList(itemCategory);

        if (inventory.Count <= 0)
            return;

        foreach (StoreableItem pod in inventory)
        {
            slots[slotIndex].PopulateSlot(pod);
            slotIndex++;
        }
    }
    public void ClearSlots()
    {
        foreach (InventorySlot slut in slots) //So laugh much funi
            slut.ClearSlot();
    }
    public void ClearOut()
    {
        gameObject.SetActive(false);
        inspectTransmitter.UnsubscribeOnChange(OnValueChange);
        ClearSlots();
    }

    public void OnValueChange()
    {
        var inventory = ItemsManager.instance.ExportInventoryList(itemCategory);

        foreach(ActionObject ao in inventory){
            if(ao.name == inspectTransmitter.Value)
            {
                inspectionItem.Copy(ao);
                holdButton.SetActive(true);
                break;
            }
        }
    }
}
