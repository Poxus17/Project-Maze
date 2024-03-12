using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_InventorManager : MonoBehaviour
{
    [SerializeField] GameObject scrollObject;
    [SerializeField] GameObject scrollContent;
    [SerializeField] GameObject background;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] float initialY;
    [SerializeField] float posDeltaY;
    [SerializeField] AudioSource audioSource;
    [Space(10)]
    [SerializeField] PastObjectEvent InspectSlot;

    bool inspectionOpen;
    bool monologPlaying;
    Dictionary<string, StoreableItem> inventoryIndex;
    AudioClip currentObjectClip;

    public static UI_InventorManager Instance;

    void Awake()
    {
        inventoryIndex = new Dictionary<string, StoreableItem>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        monologPlaying = false;
    }

    private void Start()
    {
    }

    public void ShowInventory(bool active)
    {
        gameObject.SetActive(active);

        if (active)
        {
            #region ResetScrollTransform
            scrollObject.GetComponent<RectTransform>().pivot = new Vector2(0,0.5f);
            #endregion


            StoreableItem[] inventoryArr = ItemsManager.instance.ExportInventoryList().ToArray();
            int counter = 0;

            for(int i = 0; i< scrollContent.GetComponent<RectTransform>().childCount; i++)
            {
                Destroy(scrollContent.GetComponent<RectTransform>().GetChild(i).gameObject);
            }
            inventoryIndex.Clear();

            foreach (StoreableItem item in inventoryArr)
            {
                inventoryIndex.Add("Slot" + counter, item);
                GameObject holder = Instantiate(slotPrefab, scrollContent.GetComponent<RectTransform>());
                holder.GetComponent<RectTransform>().position += (Vector3.down * posDeltaY * counter) + (Vector3.down * initialY);
                holder.name = "Slot" + counter;

                try
                {
                    holder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = item.name;
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
        var slotContent = inventoryIndex[button];

        if(!(slotContent is PastObjectData))
        {
            Debug.LogError("Request was made to inspect a non-past object item in the inventory\n" +
                slotContent.name + "\n" +
                "This should not have happened. Please check the scripts");
            return;
        }

        slotContent = slotContent as PastObjectData;
        InspectSlot.Invoke(slotContent as PastObjectData);
        background.SetActive(false);
        currentObjectClip = (slotContent as PastObjectData).clip;
        inspectionOpen = true;
    }

    public void InventoryMonolog()
    {
        if (inspectionOpen)
        {
            monologPlaying = !monologPlaying;

            if (monologPlaying)
            {
                audioSource.clip = currentObjectClip;
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }

    }
}
