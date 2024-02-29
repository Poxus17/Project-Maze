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
            Debug.Log("First section entered, setting current section to " + enteredSectionVar.value);
            currentSection = enteredSectionVar.value;
            return;
        }

        var changed = (currentSection != enteredSectionVar.value);
        if (changed)
        {
            Debug.Log("Section changed from " + currentSection + " to " + enteredSectionVar.value);
            currentSection = enteredSectionVar.value;
            OnSectionChanged.Invoke();
            return;
        }

        Debug.Log("Section not changed. Current section " + currentSection + " supposed entered section " + enteredSectionVar.value);
    }

    public bool EnterRing(int ring)
    {
        var changed = currentSection != ring;
        if (changed)
            currentSection = ring;

        return changed;
    }

}

