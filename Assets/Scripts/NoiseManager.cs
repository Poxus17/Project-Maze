using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{
    [SerializeField] AudioSource source;

    public static NoiseManager instance;

    public void SendNoise(float noise)
    {
        CentralAI.Instance.BroadcastNoise(noise, transform.position);
    }

    public void PlayNoise(AudioClip clip, float noise)
    {
        source.clip = clip;
        source.Play();

        SendNoise(noise);
    }
}
