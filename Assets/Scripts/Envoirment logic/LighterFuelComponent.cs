using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterFuelComponent : MonoBehaviour
{
    [SerializeField] FloatVariable storedFuelCans;

    public void CollectFuel(){
        storedFuelCans.value++;
        Destroy(gameObject);
    }
}
