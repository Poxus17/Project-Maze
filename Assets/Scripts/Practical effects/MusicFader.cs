using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFader : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] float fadeInTime;
    [SerializeField] float fadeOutTime;
    [SerializeField] float maxVolume;
     
    public void FadeIn() 
    {
        musicSource.volume = 0;
        musicSource.Play();
        StartCoroutine(PlayFadeIn());
    }

    IEnumerator PlayFadeIn()
    {
        var deltaTime = 0f;
        while(deltaTime < fadeInTime)
        {
            musicSource.volume = Mathf.Lerp(0, maxVolume, (deltaTime / fadeInTime));
            yield return null;
            deltaTime += Time.deltaTime;
        }

        musicSource.volume = maxVolume;
    }

    public void FadeOut()
    {
        musicSource.volume = maxVolume;
        StartCoroutine(PlayFadeOut());
    }

    IEnumerator PlayFadeOut()
    {
        var deltaTime = 0f;
        while (deltaTime < fadeOutTime)
        {
            musicSource.volume = Mathf.Lerp(maxVolume, 0, (deltaTime / fadeOutTime));
            yield return null;
            deltaTime += Time.deltaTime;
        }

        musicSource.volume = 0;

        musicSource.Pause();
    }

}
