using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] string onText = "Light up";
    [SerializeField] string offText = "Blow out";

    GameObject particles;
    public delegate void TriggerCandle(bool setTo);
    public event TriggerCandle OnTriggerCandle;

    bool lit = false;
    void Start()
    {
        particles = transform.GetChild(0).gameObject;
        particles.SetActive(lit);
    }

    public void Interact()
    {
        lit = !lit;
        particles.SetActive(lit);

        if (OnTriggerCandle != null)
        {
            OnTriggerCandle(lit);
        }
    }

    public string GetInteractionText()
    {
        return lit ? offText : onText;
    }
}
