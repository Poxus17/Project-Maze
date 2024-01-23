using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManLocalSEHandler : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public void PlaySE(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        GlobalTimerManager.instance.RegisterForTimer(() => Destroy(gameObject), clip.length);
    }
}
