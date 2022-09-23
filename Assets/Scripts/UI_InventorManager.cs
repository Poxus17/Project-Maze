using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_InventorManager : MonoBehaviour
{
    [SerializeField] GameObject scrollContent;
    [SerializeField] GameObject background;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] float initialY;
    [SerializeField] float posDeltaY;
    [Space(10)]
    [SerializeField] PastObjectEvent InspectSlot;

    bool inspectionOpen;
    Dictionary<string, PastObjectPacket> inventoryIndex;

    public static UI_InventorManager Instance;

    void Awake()
    {
        inventoryIndex = new Dictionary<string, PastObjectPacket>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ShowInventory(bool active)
    {
        gameObject.SetActive(active);

        if (active)
        {
            PastObjectPacket[] inventoryArr = InventoryManager.Instance.inventory.ToArray();
            int counter = 0;

            foreach (PastObjectPacket item in inventoryArr)
            {
                inventoryIndex.Add("Slot" + counter, item);
                GameObject holder = Instantiate(slotPrefab, scrollContent.GetComponent<RectTransform>());
                holder.GetComponent<RectTransform>().position += (Vector3.down * posDeltaY * counter) + (Vector3.down * initialY);
                holder.name = "Slot" + counter;

                try
                {
                    holder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = item.data.name;
                }
                catch (MissingComponentException e) 
                { 
                    Debug.LogError("Past Object Prefab instance has no text child object");
                }

                counter++;
            }
        }
        
    }

    public void InventoryInspection(string button)
    {
        InspectSlot.Invoke(inventoryIndex[button]);
        background.SetActive(false);
    }
}
