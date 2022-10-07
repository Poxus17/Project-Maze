using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<PastObjectPacket> inventory { get; protected set; }

    public static InventoryManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<PastObjectPacket>();
    }

    public void StoreToInventory(PastObjectPacket packet)
    {
        if (!inventory.Contains(packet))
        {
            inventory.Add(packet);
        }
    }

    public void DisplayInventory(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0 && context.action.triggered)
        {
            WorldEventDispatcher.instance.BroadcastInventoryActive.Invoke(true);
            WorldEventDispatcher.instance.SetUIActive(true);
        }
    }
}

public class InventoryObject
{

}
