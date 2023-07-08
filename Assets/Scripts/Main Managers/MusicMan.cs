using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMan : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource seSource;

    [Space(5)]
    [Header("Music transition settings")]
    [SerializeField] float maxVolume;
    [SerializeField] float transitionTime;


    public static MusicMan instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void PlaySE(AudioClip clip, float volume)
    {
        seSource.volume = volume;
        seSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip, bool useTransition)
    {
        if (useTransition)
            StartCoroutine(MusicTransition(clip));
        else
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StopSE()
    {
        seSource.Stop();
    }

    public IEnumerator MusicTransition(AudioClip clip)
    {
        var vol = musicSource.volume;
        var delta = vol * transitionTime * Time.deltaTime;

        while(vol > 0)
        {
            vol -= delta;
            musicSource.volume = vol;
            yield return null;
        }

        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();

        delta = maxVolume * transitionTime * Time.deltaTime;

        while (vol < maxVolume)
        {
            vol += delta;
            musicSource.volume = vol;
            yield return null;
        }

        musicSource.volume = maxVolume;
    }
}
