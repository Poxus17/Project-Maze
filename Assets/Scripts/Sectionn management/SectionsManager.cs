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
    [SerializeField] SectionItemIndex[] itemsIndex;

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
        if(currentSection == 0)
        {
            currentSection = section;
            return;
        }

        var changed = (currentSection != section);
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

    public GameObject GetSectionItem()
    {
        foreach(var item in itemsIndex)
        {
            if(item.section == currentSection && item.ring == currentRing)
            {
                return item.item;
            }
        }

         return null;
    }
}

[System.Serializable]
public class SectionItemIndex 
{
    public int section;
    public int ring;
    public GameObject item;

    protected bool collected = false;
}

