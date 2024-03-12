using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ScrollableValuesComponentUnorderedCombinationLock : ScrollalbeValuesComponent
{
    public string lockName;
    [SerializeField, Tooltip("Remember! Value starts at 0")] int correctSlotValue;
    [SerializeField] TriggerEventPacket onUnlock;

    private List<ScrollableValuesComponentUnorderedCombinationLock> lockComponents;

    private void Start(){
        lockComponents = GameObject.FindObjectsOfType<ScrollableValuesComponentUnorderedCombinationLock>().ToList();
        lockComponents.RemoveAll( x => x.lockName != lockName);
    }

    protected override void ApplyScroll()
    {
        if(ConfirmCombination())
            onUnlock.Invoke();
    }

    private bool ConfirmCombination(){
        if(!ConfirmSlot())
            return false;

        foreach(var lockComponent in lockComponents)
        {
            if(!lockComponent.ConfirmSlot())
                return false;
        }

        return true;
    }

    public bool ConfirmSlot(){
        return Index == correctSlotValue;
    }
}
