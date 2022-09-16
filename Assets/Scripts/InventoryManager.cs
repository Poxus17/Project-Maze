using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    List<PastObjectData> inventory;

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
        inventory = new List<PastObjectData>();
    }

    public void StoreToInventory(PastObjectData data)
    {
        if (!inventory.Contains(data))
        {
            inventory.Add(data);
        }
    }

    public void DisplayInventory(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0 && context.action.triggered)
        {
            Debug.Log("Inventory:");
            if (inventory.Count > 0)
            {
                foreach (PastObjectData data in inventory)
                {
                    Debug.Log(data.name);
                }
            }
        }
    }
}
