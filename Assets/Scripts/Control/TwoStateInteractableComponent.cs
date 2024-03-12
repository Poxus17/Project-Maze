using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TwoStateInteractableComponent : MonoBehaviour, IInteractable
{
    [Header("Default state")]
    [SerializeField] string interationTextDefault;
    [SerializeField] UnityEvent onInteractDefault;
    
    [Space(5)]
    [Header("Alt state")]
    [SerializeField] string interationTextAlt;
    [SerializeField] UnityEvent onInteractAlt;

    private bool altState = false;
    public float exclusiveTime { get => 0; set => throw new NotImplementedException(); }

    public string GetInteractionText()
    {
        return altState ? interationTextAlt : interationTextDefault;
    }

    public void Interact()
    {
        if (altState)
            onInteractAlt.Invoke();
        else
            onInteractDefault.Invoke();
    }

    public void SwitchState()
    {
        altState = !altState;
    }

    public bool InteractionAllowed() { return true; }
}
