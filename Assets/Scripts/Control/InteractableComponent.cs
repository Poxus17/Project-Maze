using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableComponent : MonoBehaviour, IInteractable
{
    [SerializeField] string intreactionText;
    [SerializeField] UnityEvent Interaction;
    public void Interact()
    {
        Interaction.Invoke();
    }

    public string GetInteractionText()
    {
        return intreactionText;
    }

}
