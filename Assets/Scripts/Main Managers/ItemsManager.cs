using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ItemsManager : MonoBehaviour
{
    #region All Items
    public StoreableItem[] allItems;

    #if UNITY_EDITOR
    public void LoadInItems(string[] guids)
    {
        allItems = new StoreableItem[guids.Length];

        for (int i = 0; i < guids.Length; i++)
        {
            allItems[i] = AssetDatabase.LoadAssetAtPath<StoreableItem>(AssetDatabase.GUIDToAssetPath(guids[i]));
            PrefabUtility.RecordPrefabInstancePropertyModifications(this);
        }
    }
    #endif
    #endregion

    [SerializeField] PastObjectData InspectionPacket;
    [SerializeField] FloatVariable itemCount;
    [SerializeField] IntVariable placedCount;
    
    private AudioSource audioSource;
    private bool[] inventoryMemory;
    private bool[] placedMemory;

    public static ItemsManager instance;
    private void Awake(){
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        audioSource = GetComponent<AudioSource>();
        inventoryMemory = new bool[allItems.Length];
        placedMemory = new bool[allItems.Length];
    }

    public void AddMemory(PastObjectData packet)
    {
        itemCount.value++;

        audioSource.clip = packet.clip;
        audioSource.Play();
        InspectionPacket.Copy(packet);

        AddItem(packet.name);
    }

    public List<StoreableItem> ExportInventoryList()
    {
        List<StoreableItem> toReturn = new List<StoreableItem>();

        for (int i = 0; i < allItems.Length; i++)
            if (inventoryMemory[i])
                toReturn.Add(allItems[i]);

        return toReturn;
    }

    public List<StoreableItem> ExportInventoryList(ItemCategory category)
    {
        List<StoreableItem> toReturn = new List<StoreableItem>();

        for (int i = 0; i < allItems.Length; i++)
            if (inventoryMemory[i] && allItems[i].category == category)
                toReturn.Add(allItems[i]);

        return toReturn;
    }

    public StoreableItem GetItem(int index)
    {
        return allItems[index];
    }

    public StoreableItem GetItem(string name)
    {
        foreach(StoreableItem popv in allItems)
        {
            if (popv.name == name)
                return popv;
        }

        Debug.LogError("Item get request faild\n" +
            "Could not find item [" + name + "] in allItems list");
        return null;
    }

    public void RemoveItem(string name)
    {
        for (int i = 0; i < allItems.Length; i++)
            if (allItems[i].name == name)
                inventoryMemory[i] = false;
    }

    public void AddItem(string name)
    {
        for (int i = 0; i < allItems.Length; i++)
            if (allItems[i].name == name)
            {
                inventoryMemory[i] = true;
            }
    }

    public void PlaceItem(string name)
    {
        for (int i = 0; i < allItems.Length; i++)
            if (allItems[i].name == name)
            {
                inventoryMemory[i] = false;
                placedMemory[i] = true;
            }
    }

    #region Save system functions
    public bool[] GetInventoryData() { return inventoryMemory; }

    public bool[] GetPlacementData(){ return placedMemory; }

    public void SetInventoryData(bool[] inventoryData) { inventoryMemory = inventoryData; }

    public void SetPlacedData(bool[] placedData) { placedMemory = placedData; }

    public void CountItems()
    {
        itemCount.value = 0;
        placedCount.value = 0;
        
        for(int i = 0; i<allItems.Length; i++)
        {
            if (inventoryMemory[i])
                itemCount.value++;

            if (placedMemory[i])
            {
                itemCount.value++;
                placedCount.value++;
            }
        }

        Debug.Log("Items counted. Updated item count: " + itemCount.value + ", Updated placed count: " + placedCount.value);
    }

    public void MatchItemObjectState()
    {
        List<string> takenObjects = new List<string>();
        List<string> placedObjecs = new List<string>();

        for(int i = 0; i<allItems.Length; i++)
        {
            if(placedMemory[i])
            {
                takenObjects.Add(allItems[i].name);
                placedObjecs.Add(allItems[i].name);
            }
            else if(inventoryMemory[i])
            {
                takenObjects.Add(allItems[i].name);
            }

        }

        ObjectInteractionComponent[] interactionComponents = FindObjectsOfType<ObjectInteractionComponent>();
        foreach (ObjectInteractionComponent oic in interactionComponents)
        {
            oic.SetItemObjectState(takenObjects);
        }

        ItemPlacementComponent[] placementComponents = FindObjectsOfType<ItemPlacementComponent>();
        foreach(ItemPlacementComponent ipc in placementComponents)
        {
            ipc.MatchSlotToMemory(placedObjecs);
        }
    }
    #endregion
}

[CustomEditor(typeof(ItemsManager), true)]
public class ItemsManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Called whenever the inspector is drawn for this object.
        DrawDefaultInspector();

        ItemsManager itemsManager = (ItemsManager)target;

        if(GUILayout.Button("Find all items")){
            string[] guids = AssetDatabase.FindAssets("t:StoreableItem");
            itemsManager.LoadInItems(guids);
        }

    }
}
