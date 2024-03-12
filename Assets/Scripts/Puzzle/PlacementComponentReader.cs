using UnityEngine;

public class PlacementComponentReader : PlacementComponent
{
    private LayerMask layerMask;
    public void ReadValue(){
        if(placementTransmitter.Value == null) return;

        placementTransmitter.Value.position = transform.position;
    }

    public override void PostInit(){
        layerMask = gameObject.layer;
        gameObject.layer = 0;

        placementTransmitter.SubscribeOnChange(ActivateInteraction);
        placementTransmitter.SubscribeOnClear(DeactivateInteraction);
    }

    public void ActivateInteraction(){
        gameObject.layer = layerMask;
    }

    public void DeactivateInteraction(){
        gameObject.layer = 0;
    }
}
