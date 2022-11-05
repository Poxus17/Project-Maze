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
        currentSection = 0;
    }

    public void EnterSection(int section)
    {
        var changed = currentSection != section;
        if (changed)
        {
            currentSection = section;
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
