using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMan : MonoBehaviour
{
    [SerializeField] AudioSource source;

    public static MusicMan instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void PlaySE(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
