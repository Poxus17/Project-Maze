using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SectionsManager : MonoBehaviour
{
    public int currentRing { get; private set; }
    public int currentSection { get; private set; }

    [SerializeField] UnityEvent OnSectionChanged;
    [SerializeField] UnityEvent OnRingChanged;
    [SerializeField] IntVariable enteredSectionVar;

    public static SectionsManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        currentRing = 1;
        currentSection = -1;
    }

    public void SetSection(int section)
    {
        enteredSectionVar.value = section;
    }

    public void EnterSection()
    {

        if(currentSection == -1)
        {
            currentSection = enteredSectionVar.value;
            return;
        }

        var changed = (currentSection != enteredSectionVar.value);
        if (changed)
        {
            currentSection = enteredSectionVar.value;
            OnSectionChanged.Invoke();
        }
    }

    public bool EnterRing(int ring)
    {
        var changed = currentSection != ring;
        if (changed)
            currentSection = ring;

        return changed;
    }

}

