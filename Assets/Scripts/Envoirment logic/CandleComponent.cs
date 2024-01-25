using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleComponent : MonoBehaviour, IInteractable
{
    public float exclusiveTime { get; set; }

    [SerializeField] BoolVariable lighterLit;
    [SerializeField] string onText = "Light up";
    [SerializeField] string offText = "Blow out";
    [SerializeField] float candleIntensity;
    [SerializeField] bool startLit;
    
    private Light volumatric;
    private GameObject particles;
    private bool lit;
    private CandleBatchIntensityVariable candleBatchIntensityVariable;

    void Awake()
    {
        lit = startLit;

        particles = GetComponentInChildren<ParticleSystem>().gameObject;
        particles.SetActive(lit);
        volumatric = GetComponentInChildren<Light>();
    }

    public void InitCandle(CandleBatchIntensityVariable candleBatch){
        
        candleBatchIntensityVariable = candleBatch;
        PostInit();
    }

    private void PostInit(){
        if(lit)
            candleBatchIntensityVariable.AddIntensity(candleIntensity);
    }

    public void Interact()
    {
       if (!InteractionAllowed() && !lit)
            return;

        lit = !lit;
        particles.SetActive(lit);
        volumatric.enabled = lit;

        var litMod = lit ? 1 : -1;
        candleBatchIntensityVariable.AddIntensity(litMod * candleIntensity);
    }

    public string GetInteractionText(){
        return lit ? offText : onText;
    }

    public bool InteractionAllowed(){
        return lighterLit.value;
    }
}
