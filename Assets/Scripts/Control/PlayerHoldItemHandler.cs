using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldItemHandler : MonoBehaviour
{
    [SerializeField] Transform HoldItemTransform;
    [SerializeField] PastObjectPacketVariable inspectionItem;
    [SerializeField] BoolVariable isHolding;
    public void RequestPlayerHoldItem()
    {
        var success = HoldItemManager.instance.TakeItem(inspectionItem.Value.data.name, HoldItemTransform);

        if (success)
            isHolding.value = true;
    }

    public void DismissPlayerHoldItem(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.started && isHolding.value)
        {
            HoldItemManager.instance.ShelveItem();
            isHolding.value = false;
        }
    }
}
