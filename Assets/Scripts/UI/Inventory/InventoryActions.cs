using UnityEngine;

public class InventoryActions : MonoBehaviour, IInventorySection
{
    [SerializeField] InventorySlot[] slots;
    [SerializeField] GameObject holdButton;

    private ValueTransmitter<string> inspectTransmitter;

    private void Awake(){
        inspectTransmitter = new ValueTransmitter<string>();
        //inspectTransmitter.SubscribeOnChange();

        foreach(InventorySlot slut in slots){
            
        }
    }

    public void Launch()
    {
        throw new System.NotImplementedException();
    }
    public void DisplayInventory()
    {

    }
    public void ClearSlots()
    {

    }
    public void ClearOut()
    {
        throw new System.NotImplementedException();
    }
}
