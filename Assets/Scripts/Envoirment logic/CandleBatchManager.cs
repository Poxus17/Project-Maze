using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CandleBatchManager : MonoBehaviour
{
    private Light lightComponent;
    private List<CandleComponent> candleTriggers;
    private CandleBatchIntensityVariable candleBatchIntensityVariable;

    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponentsInChildren<Light>()[0];

        candleTriggers = new List<CandleComponent>();
        candleTriggers = GetComponentsInChildren<CandleComponent>().ToList();

        candleBatchIntensityVariable = new CandleBatchIntensityVariable();
        candleBatchIntensityVariable.Subscribe(UpdateLight);

        foreach(CandleComponent candleTrigger in candleTriggers){
            candleTrigger.InitCandle(candleBatchIntensityVariable);
        }
    }

    private void UpdateLight(){
        lightComponent.intensity = candleBatchIntensityVariable.Intensity;
    }
}

public class CandleBatchIntensityVariable{
    private float _intensity;
    private Action _onIntensityChange;
    public float Intensity => _intensity;
    
    public CandleBatchIntensityVariable(){
        _intensity = 0;
    }

    public void Subscribe(Action action){
        _onIntensityChange += action;
    }

    public void SetIntensity(float intensity){
        _intensity = intensity;
        _onIntensityChange.Invoke();
    }

    public void AddIntensity(float intensity){
        _intensity += intensity;
        _onIntensityChange.Invoke();
    }
}
