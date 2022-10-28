using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KellekMusicManager : MonoBehaviour
{
    [SerializeField] AudioSource[] phaseSources;
    [SerializeField] AudioSource chaseSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    void ActivatePhases(bool setTo)
    {
        foreach (var phase in phaseSources)
        {
            phase.enabled = setTo;
        }
    }

    public void ActivateChase(bool active)
    {
        chaseSource.enabled = active;
        ActivatePhases(!active);

        if(active)
            chaseSource.Play();
        else
            chaseSource.Stop();
    }

}