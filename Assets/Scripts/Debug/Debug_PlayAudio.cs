using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_PlayAudio : MonoBehaviour
{
    public void PlaySE(AudioClip clip)
    {
        MusicMan.instance.PlaySE(clip, 1);
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicMan.instance.PlayMusic(clip, false);
    }
}
