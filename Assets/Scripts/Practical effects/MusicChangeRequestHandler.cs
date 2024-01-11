using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Obsolete("DEPRECATED by MusicManAgent")]
public class MusicChangeRequestHandler : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] bool useTransition;
    [SerializeField] bool isMainTrack;

    public void ChangeToClip()
    {
        MusicMan.instance.PlayMusic(clip, useTransition, isMainTrack);
    }

    public void ReturnToMain(){
        MusicMan.instance.ResetToMainTrack();
    }
}
