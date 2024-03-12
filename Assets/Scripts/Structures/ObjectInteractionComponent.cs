using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ObjectInteractionComponent : MonoBehaviour
{ 
    [SerializeField] PastObjectData data;
    [SerializeField] GameEvent inspectionExitEvent;

    void Start()
    {
        gameObject.layer = 6;
    }

    public void Interact()
    {
        ItemsManager.instance.AddMemory(data);

        UIManager.Instance.LaunchUIComponent(0);

        if(inspectionExitEvent != null)
            UIManager.Instance.BindGameEventToExit(inspectionExitEvent);

        Banish();

        SaveManager.instance.SaveGame();
    }

    private void Banish()
    {
        //Send it to FUCKING HELL never to be seen again
        //transform.position = new Vector3(0, -100, 0);
        gameObject.SetActive(false);
    }

    public void SetItemObjectState(List<string> takenItems)
    {
        if (takenItems.Contains(data.name))
        {
            Banish();
        }
    }
}


