using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleTrigger : MonoBehaviour, IInteractable
{
    public float exclusiveTime { get; set; }
    [SerializeField] BoolVariable lighterLit;
    [SerializeField] string onText = "Light up";
    [SerializeField] string offText = "Blow out";
    
    Light volumatric;

    GameObject particles;
    public delegate void TriggerCandle(bool setTo);
    public event TriggerCandle OnTriggerCandle;

    bool lit = false;
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>().gameObject;
        particles.SetActive(lit);
        volumatric = GetComponentInChildren<Light>();
    }

    public void Interact()
    {
        if (!InteractionAllowed())
            return;

        lit = !lit;
        particles.SetActive(lit);
        volumatric.enabled = lit;

        if (OnTriggerCandle != null)
        {
            OnTriggerCandle(lit);
        }
    }

    public string GetInteractionText()
    {
        return lit ? offText : onText;
    }

    public bool InteractionAllowed()
    {
        return (lighterLit == null) ? true : lighterLit.value;
    }
}
