using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterFuelComponent : IndexedConsumable
{
    [SerializeField] GameEvent collectFuelCanEvent;

    public void CollectFuel(){
        collectFuelCanEvent.Raise();
        RegisterAsConsumed();
        Destroy(gameObject);
    }
}
