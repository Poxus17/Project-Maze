using UnityEngine;
using UnityEngine.Events;

public class ItemPlacementManager : MonoBehaviour
{
    [SerializeField] GameEvent AnnouncePlacement;
    [SerializeField] ValueGatedUnityEvent[] events;
    [SerializeField] IntVariable itemCounter;

    public static ItemPlacementManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void ResetCounter()
    {
        itemCounter.value = 0;
    }

    public void PlaceItem()
    {
        AnnouncePlacement.Raise();
        itemCounter.value++;

        Debug.Log("Item placed. ItemPlacementManager updated count: " + itemCounter.value);

        foreach(ValueGatedUnityEvent vgue in events)
        {
            if (vgue.InvokeAllowed(itemCounter.value))
            {
                vgue.gatedEvent.Raise();
                vgue.placementEvent.Invoke();
                break;
            }
        }
    }

    public void RaiseAllEventsLoad(){
        Debug.Log("Loading all item place events. Item count: " + itemCounter.value);

        for(int i = 0; i <= itemCounter.value; i++){
            foreach(ValueGatedUnityEvent vgue in events)
            {
                if (vgue.InvokeAllowed(i))
                {
                    Debug.Log("Raising event: " + vgue.gatedEvent.name + " with count: " + i);
                    vgue.gatedEvent.Raise();
                    break;
                }
            }
        }
    }
}

[System.Serializable]
public class ValueGatedUnityEvent
{
    public int requiredCount;
    public GameEvent gatedEvent;
    public UnityEvent placementEvent; //Only fires when the item placed brings the count to the required count.

    public bool InvokeAllowed(int count)
    {
        return count == requiredCount;
    }
}

