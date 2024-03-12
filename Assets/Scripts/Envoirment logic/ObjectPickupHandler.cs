using UnityEngine;
using System.Collections.Generic;

public class ObjectPickupHandler : MonoBehaviour
{
    [SerializeField] string objectName;
    public void Pickup(){
        ItemsManager.instance.AddItem(objectName);
        Banish();
    }

    private void Banish()
    {
        gameObject.SetActive(false);
    }

    public void SetItemObjectState(List<string> takenItems)
    {
        if (takenItems.Contains(objectName))
        {
            Banish();
        }
    }
}
