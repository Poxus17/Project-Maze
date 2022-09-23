using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public void ButtonEvent()
    {
        UI_InventorManager.Instance.InventoryInspection(gameObject.name);
    }
}
