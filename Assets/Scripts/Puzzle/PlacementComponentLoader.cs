using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MouseStick))]
public class PlacementComponentLoader : PlacementComponent
{
    [SerializeField] UnityEvent onCleared; //This is me giving up
    private MouseStick mouseStick;

    public override void Init(ValueTransmitter<Transform> valueTransmitter)
    {
        mouseStick = GetComponent<MouseStick>();
        base.Init(valueTransmitter);
        placementTransmitter.SubscribeOnClear(CheckClear);
    }

    public void LoadValue()
    {
        mouseStick.EnableMouseStick();
        placementTransmitter.SetValue(transform);
    }

    public void CheckClear()
    {
        if (placementTransmitter.Value == transform){
            mouseStick.DisableMouseStick();
            onCleared.Invoke();
        }
            
    }
}
