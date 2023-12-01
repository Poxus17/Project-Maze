using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

[RequireComponent(typeof(Light))]
public class CandleLightingController : MonoBehaviour
{
    [SerializeField] CandleTrigger[] triggers;
    [SerializeField] float deltaIntensity;

    HDAdditionalLightData lightComponent;

    float currentIntensity = 0;
    int litCandles = 0;
    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<HDAdditionalLightData>();
        lightComponent.intensity = 0;

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
