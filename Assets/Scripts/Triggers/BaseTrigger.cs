using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrigger : MonoBehaviour
{
    [Header("Trigger Settings"), Space(5)]
    [SerializeField] TriggerEventPacket triggerEventPacket; //trigger event packet.
    [SerializeField] protected bool consumeable = false; //if true, trigger will be consumed after first activation.
    [SerializeField] protected bool triggerOnce = false; //if true, trigger will only activate once.
    [SerializeField] protected bool active = true; //if false, trigger will not activate.

    public virtual void SetActive(bool active){
        this.active = active;
    }

    public virtual void Trigger(){

        if(!active) return;
        triggerEventPacket.Invoke();

        if(triggerOnce) active = false;
        if(consumeable) gameObject.SetActive(false);
    }
}

