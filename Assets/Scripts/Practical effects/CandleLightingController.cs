using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class CandleLightingController : MonoBehaviour
{
    [SerializeField] CandleTrigger[] triggers;
    [SerializeField] float deltaIntensity;

    Light lightComponent;

    float currentIntensity = 0;
    int litCandles = 0;
    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();

        foreach(CandleTrigger trigger in triggers)
        {
            trigger.OnTriggerCandle += TriggerLight;
        }
    }

    void TriggerLight(bool setActive)
    {
        int mod = setActive ? 1 : -1;
        currentIntensity += mod * deltaIntensity;
        lightComponent.intensity = currentIntensity;
    }

    private void OnDestroy()
    {
        foreach (CandleTrigger trigger in triggers)
        {
            trigger.OnTriggerCandle -= TriggerLight;
        }
    }
}
