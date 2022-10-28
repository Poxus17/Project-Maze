using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionsManager : MonoBehaviour
{
    int currentRing = 1;
    int currentSection = 0;

    public static SectionsManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public bool EnterSection(int section, int ring)
    {
        var changed = currentSection != section;
        if (changed)
            currentSection = section;

        return changed;
    }
}
