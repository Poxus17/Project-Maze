using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldItemHandler : MonoBehaviour
{
    [SerializeField] Transform HoldItemTransform;
    [SerializeField] PhysicalObject inspectionItem;
    [SerializeField] BoolVariable isHolding;
    [SerializeField] AudioClip TakeItemClip;
    [SerializeField] AudioClip ShelveItemClip;

    public void RequestPlayerHoldItem()
    {
        var success = HoldItemManager.instance.TakeItem(inspectionItem.name, HoldItemTransform);

        if (success){
            MusicMan.instance.PlaySE(TakeItemClip);
            isHolding.value = true;
        }
            
    }

    public void DismissPlayerHoldItem(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.started && isHolding.value)
        {
            HoldItemManager.instance.ShelveItem();
            isHolding.value = false;
            MusicMan.instance.PlaySE(ShelveItemClip);
        }
    }
}
