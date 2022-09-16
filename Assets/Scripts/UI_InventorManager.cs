using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventorManager : MonoBehaviour
{
    [SerializeField] GameObject scrollContent;
    [SerializeField] GameObject background;

    bool inspectionOpen;

    public void ShowInventory(bool active)
    {
        gameObject.SetActive(active);
    }
}
