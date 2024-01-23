using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterFuelComponent : MonoBehaviour
{
    [SerializeField] float fuelAmount;
    [SerializeField] FloatVariable fuel;

    public void CollectFuel(){
        fuel.value += fuelAmount;
        Destroy(gameObject);
    }
}
