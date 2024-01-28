using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterFuelComponent : MonoBehaviour
{
    [SerializeField] GameEvent collectFuelCanEvent;

    public void CollectFuel(){
        collectFuelCanEvent.Raise();
        Destroy(gameObject);
    }
}
