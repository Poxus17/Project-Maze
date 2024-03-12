using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
    private PlacementComponent[] placementComponents;
    private ValueTransmitter<Transform> placementTransmitter;
    private void Start()
    {
        placementComponents = GetComponentsInChildren<PlacementComponent>();
        placementTransmitter = new ValueTransmitter<Transform>();

        foreach (var component in placementComponents)
        {
            component.Init(placementTransmitter);
        }
    }
}

public class PlacementComponent : MonoBehaviour{
    protected ValueTransmitter<Transform> placementTransmitter;
    public virtual void Init(ValueTransmitter<Transform> valueTransmitter){
        placementTransmitter = valueTransmitter;
        PostInit();
    }

    public virtual void PostInit(){}

    public void ClearValue(){
        placementTransmitter.ClearValue();
    }
}