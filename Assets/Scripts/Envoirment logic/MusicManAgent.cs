using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManAgent : MonoBehaviour
{
    public void PlayClipAsMusic(AudioClip clip, bool useTransition)
    {
        if(SaveManager.instance.isLoading) return;
        
        MusicMan.instance.PlayMusic(clip, useTransition);
    }

    public void PlayClipAsSE(AudioClip clip)
    {
        if(SaveManager.instance.isLoading) return;

        MusicMan.instance.PlaySE(clip, 1);
    }
}

