using UnityEngine;
using System.Collections.Generic;

public class InventoryMemories : MonoBehaviour, IInventorySection
{
    [SerializeField] InventorySlot[] slots;
    [SerializeField] ItemCategory itemCategory;
    [SerializeField] PastObjectData inspectionItem;
    [SerializeField] GameObject background;
    [SerializeField] GameObject holdButton;

    private ValueTransmitter<string> inspectTransmitter;


    public void ClearOut()
    {
        gameObject.SetActive(false);
        ClearSlots();
    }

    public void ClearSlots()
    {
        foreach (InventorySlot slut in slots) //So laugh much funi
            slut.ClearSlot();
    }

    public void DisplayInventory()
    {
        ClearSlots();
        int slotIndex = 0;
        background.SetActive(true);

        List<StoreableItem> inventory = ItemsManager.instance.ExportInventoryList(itemCategory);

        if (inventory.Count <= 0)
            return;

        foreach (StoreableItem pod in inventory)
        {
            slots[slotIndex].PopulateSlot(pod);
            slotIndex++;
        }
    }

    public void Launch()
    {
        gameObject.SetActive(true);
        inspectTransmitter = new ValueTransmitter<string>();
        inspectTransmitter.SubscribeOnChange(InspectFromInventory);

        foreach(InventorySlot slut in slots){
            slut.Init(inspectTransmitter);
        }

        DisplayInventory();
    }

    public void InspectFromInventory()
    {
        background.SetActive(false);
        holdButton.SetActive(true);

        List<StoreableItem> inventory = ItemsManager.instance.ExportInventoryList();

        foreach (PastObjectData pod in inventory)
        {
            if(pod.name == inspectTransmitter.Value)
            {
                inspectionItem.Copy(pod);
                UIManager.Instance.LaunchNestedUIComponent(0);
                break;
            }
        }
    }
}
