using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Profiling;

[System.Serializable]
public class TriggerEventPacket{
    public UnityEvent localEvent;
    public List<GameEvent> publicEvents;

    public TriggerEventPacket(UnityEvent localEvent){
        this.localEvent = localEvent;
        this.publicEvents = new List<GameEvent>();
    }

    public void Invoke(){

        Profiler.BeginSample("TriggerEventPacket.Invoke");
        
        localEvent.Invoke();

        foreach(GameEvent gameEvent in publicEvents){
            gameEvent.Raise();
        }

        Profiler.EndSample();
    }
}