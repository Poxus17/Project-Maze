using UnityEngine;
using UnityEngine.Events;

public class ItemPlacementManager : MonoBehaviour
{
    [SerializeField] GameEvent AnnouncePlacement;
    [SerializeField] ValueGatedUnityEvent[] events;
    int itemCounter;

    public static ItemPlacementManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void PlaceItem()
    {
        AnnouncePlacement.Raise();
        itemCounter++;

        foreach(ValueGatedUnityEvent vgue in events)
        {
            if (vgue.InvokeAllowed(itemCounter))
            {
                vgue.gatedEvent.Raise();
                break;
            }
        }
    }

}

[System.Serializable]
public class ValueGatedUnityEvent
{
    public int requiredCount;
    public GameEvent gatedEvent;

    public bool InvokeAllowed(int count)
    {
        return count == requiredCount;
    }
}

