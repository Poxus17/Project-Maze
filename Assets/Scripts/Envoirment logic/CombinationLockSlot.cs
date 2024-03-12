using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombinationLockSlot : MonoBehaviour, IIndexRecipient
{
    public string lockName;
    [SerializeField, Tooltip("Remember! Value starts at 0")] int correctSlotValue;
    [SerializeField] TriggerEventPacket onUnlock;

    private List<CombinationLockSlot> lockComponents;
    private int index;
    private bool locked = false;

    private void Start(){
        lockComponents = GameObject.FindObjectsOfType<CombinationLockSlot>().ToList();
        lockComponents.RemoveAll( x => x.lockName != lockName);
    }

    public void SetIndex(int newIndex){
        index = newIndex;

        if(ConfirmCombination()){
            onUnlock.Invoke();
            locked = true;
        }
            
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
        return locked ? false : index == correctSlotValue;
    }

}
