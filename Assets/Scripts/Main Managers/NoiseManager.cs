using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{
    public static NoiseManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SendNoise(float noise)
    {
        CentralAI.Instance.BroadcastNoise(noise, transform.position);
    }

    public void PlayNoise(AudioClip clip, float noise, float volume = 1.0f)
    {
        MusicMan.instance.PlaySE(clip, volume);

        SendNoise(noise);
    }
}
