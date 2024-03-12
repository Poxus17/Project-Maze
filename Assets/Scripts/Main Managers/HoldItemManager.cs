using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItemManager : MonoBehaviour
{
    [SerializeField] HoldItem[] items;
    GameObject heldItem;

    private List<HoldItem> currentHoldInventory;
    public static HoldItemManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        currentHoldInventory = new List<HoldItem>();
    }

    public bool TakeItem(string name, Transform holdParent)
    {
        var item = GetItemByName(name);

        #region Catch empty item
        if (item.name == "empty")
        {
            Debug.LogError("HoldItemManager could not find requested HoldItem \nItem name: " + name);
            return false; //Operation failed
        }
        #endregion

        if (heldItem != null)
            ShelveItem();

        var rotationRecord = item.item.transform.localEulerAngles;

        item.item.transform.SetParent(holdParent);
        item.item.transform.localPosition = Vector3.zero;
        item.item.transform.localEulerAngles = rotationRecord;

        heldItem = item.item;

        return true; //Operation sucessful
    }

    public void ShelveItem()
    {
        if (heldItem == null)
            return;

        var rotationRecord = heldItem.transform.localEulerAngles;

        heldItem.transform.SetParent(gameObject.transform);
        heldItem.transform.localPosition = Vector3.zero;
        heldItem.transform.localEulerAngles = rotationRecord;

        heldItem = null;
    }

    HoldItem GetItemByName(string name)
    {
        foreach(HoldItem hi in items)
        {
            if (hi.name == name)
                return hi;
        }

        return HoldItem.Empty;
    }

    public void RegisterHoldItem(PhysicalObject item){

        return; //TODO: Implement this
        var itemObject = Instantiate(item.itemPrefab, transform);

        var holdItem = new HoldItem(item.name, itemObject);
        currentHoldInventory.Add(holdItem);

        #if UNITY_EDITOR
        Debug.Log("Added item to hold, printing hold inventory");
        foreach(HoldItem hi in currentHoldInventory){
            Debug.Log(hi.name);
        }
        #endif
    }

    public void RemoveHoldItem(string name){
        foreach(HoldItem hi in currentHoldInventory){
            if(hi.name == name){
                Destroy(hi.item);
                currentHoldInventory.Remove(hi);
                return;
            }
        }
    }
}

[System.Serializable]
public class HoldItem{
    public string name;
    public GameObject item;

    public static readonly HoldItem Empty = new HoldItem("empty", null);

    public HoldItem(string name, GameObject item){
        this.name = name;
        this.item = item;
    }
}
