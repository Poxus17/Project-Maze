using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreehouseEntracneComponent : MonoBehaviour
{
    [SerializeField] GameEvent UseEntrance;

    public void Interact()
    {
        UseEntrance.Raise();
    }
}
