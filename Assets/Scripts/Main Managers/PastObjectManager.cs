using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class PastObjectManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] PastObjectData[] allItems;
    [SerializeField] PastObjectData InspectionPacket;
    [SerializeField] FloatVariable itemCount;

    bool[] inventoryMemory; //Has the data of which items are in the inventory
    bool[] placedMemory;

    public string text { get; }

    public static PastObjectManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        itemCount.value = 0;
#endif
        audioSource = GetComponent<AudioSource>();
        inventoryMemory = new bool[allItems.Length];
        placedMemory = new bool[allItems.Length];
    }

    public void Interact(PastObjectData packet)
    {
        itemCount.value++;

        audioSource.clip = packet.clip;
        audioSource.Play();
        InspectionPacket.Copy(packet);

        //EnterInspection.Raise();
        /*WorldEventDispatcher.instance.BroadcastInteraction.Invoke(packet);*/

        //InventoryManager.Instance.StoreToInventory(packet);

        AddItem(packet.name); //NEEDS CHANGE, NO NEED TO DELIVER THE PACKET!

    }

    public List<PastObjectData> ExportInventoryList()
    {
        List<PastObjectData> toReturn = new List<PastObjectData>();

        for (int i = 0; i < allItems.Length; i++)
            if (inventoryMemory[i])
                toReturn.Add(allItems[i]);

        return toReturn;
    }

    public PastObjectData GetItem(int index)
    {
        return allItems[index];
    }

    public PastObjectData GetItem(string name)
    {
        foreach(PastObjectData popv in allItems)
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
                inventoryMemory[i] = true;
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

/*
[System.Serializable]
public class PastObjectPacket
{
    public PastObjectData data { get; protected set; }
    public GameObject gameObject { get; protected set; }
    public Vector3 scale { get; protected set; }
    public Vector3 eularRotation { get; protected set; }

    public PastObjectPacket(PastObjectData pastObject, GameObject gameObject)
    {
        this.data = pastObject;
        this.gameObject = gameObject;
        this.scale = gameObject.transform.localScale;
        this.eularRotation = gameObject.transform.localEulerAngles;
    }
}*/
