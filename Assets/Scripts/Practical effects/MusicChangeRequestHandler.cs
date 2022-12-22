using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChangeRequestHandler : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] bool useTransition;

    public void ChangeToClip()
    {
        MusicMan.instance.PlayMusic(clip, useTransition);
    }
}
