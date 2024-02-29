using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItemManager : MonoBehaviour
{
    [SerializeField] HoldItem[] items;
    GameObject heldItem;

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
}

[System.Serializable]
public class HoldItem{
    public string name;
    public GameObject item;

    public static readonly HoldItem Empty = new HoldItem()
    {
        name = "empty",
        item = null
    };
}
