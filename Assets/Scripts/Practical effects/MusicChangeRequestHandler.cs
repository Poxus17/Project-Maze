using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Obsolete("DEPRECATED by MusicManAgent")]
public class MusicChangeRequestHandler : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] bool useTransition;

    public void ChangeToClip()
    {
        MusicMan.instance.PlayMusic(clip, useTransition);
    }
}
