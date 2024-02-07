using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelHandler : MonoBehaviour
{
    [SerializeField] float fuelAmountPerCan = 60f;
    [SerializeField] FloatVariable fuelCounter;
    [SerializeField] FloatVariable fuelAmount;

    public void CollectFuel(){
        fuelCounter.value++;
    }

    public void UseFuelCan(UnityEngine.InputSystem.InputAction.CallbackContext context){
        if(!context.performed)
            return;
        
        if(fuelCounter.value <= 0)
            return;

        fuelCounter.value--;
        fuelAmount.value = Mathf.Clamp(fuelAmount.value + fuelAmountPerCan, 0f, 350f);

    }

}
