using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : UIComponent
{
    [SerializeField] InventorySlot[] slots;
    [SerializeField] PastObjectData inspectionItem;
    [SerializeField] GameObject background;
    [SerializeField] GameObject holdButton;

    //public List<PastObjectPacket> inventory { get; protected set; }

    public static InventoryManager Instance { get; private set; }

    public override void PersonalEventBindings()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        LaunchComponentPersonalEvents += DisplayInventory;

    }

    /*public void StoreToInventory(PastObjectPacket packet)
    {
        if (!inventory.Contains(packet))
        {
            inventory.Add(packet);
        }
    }*/

    public void DisplayInventory()
    {
        ClearSlots();
        int slotIndex = 0;
        background.SetActive(true);

        List<PastObjectData> inventory = PastObjectManager.instance.ExportInventoryList();

        if (inventory.Count <= 0)
            return;

        foreach (PastObjectData pod in inventory)
        {
            slots[slotIndex].PopulateSlot(pod);
            slotIndex++;
        }
    }

    private void ClearSlots()
    {
        foreach (InventorySlot slut in slots) //So laugh much funi
            slut.ClearSlot();
    }

    public void InspectFromInventory(string name)
    {
        background.SetActive(false);
        holdButton.SetActive(true);

        List<PastObjectData> inventory = PastObjectManager.instance.ExportInventoryList();

        foreach (PastObjectData pod in inventory)
        {
            if(pod.name == name)
            {
                inspectionItem.Copy(pod);
                UIManager.Instance.LaunchNestedUIComponent(0);
            }
        }
    }

    /*public void RemoveFromInventory(PastObjectPacket item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
        }
    }*/
}