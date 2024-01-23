using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Space(5)]
    [SerializeField] GameObject localSePrefab;

    private AudioClip mainMusicTrack;
    private DynamicReverbMusicBoy reverbMusicBoy;

    public static MusicMan instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        reverbMusicBoy = GetComponentInChildren<DynamicReverbMusicBoy>();
    }

    public void PlaySE(AudioClip clip, float volume)
    {
        seSource.volume = volume;
        seSource.PlayOneShot(clip);
    }

    public void PlaySE(AudioClip clip)
    {
        seSource.volume = 1;
        seSource.PlayOneShot(clip);
    }

    public void PlayLocalSE(AudioClip clip, Vector3 position)
    {
        var go = Instantiate(localSePrefab, position, Quaternion.identity);
        var handler = go.GetComponent<MusicManLocalSEHandler>();
        handler.PlaySE(clip);
    }

    public void PlaySEWithReverb(AudioClip clip, float distance)
    {
        reverbMusicBoy.PlayClipWithReverb(clip, distance);
    }

    public void PlayMusic(AudioClip clip, bool useTransition, bool isMainTrack = false)
    {
        if (isMainTrack)
            mainMusicTrack = clip;

        if (useTransition)
            StartCoroutine(MusicTransition(clip));
        else
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    public void ResetToMainTrack()
    {
        //if there was no main track set, just stop the music
        if (mainMusicTrack == null){
            musicSource.Stop();
            return;
        }

        //If it's reseting back to the already playing track, don't do anything
        if(musicSource.clip == mainMusicTrack)
            return;

        musicSource.clip = mainMusicTrack;
        musicSource.Play();
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
