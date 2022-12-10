using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreehouseEntracneComponent : MonoBehaviour, IInteractable
{
    [SerializeField] GameEvent UseEntrance;

    public void Interact()
    {
        UseEntrance.Raise();
    }
}
