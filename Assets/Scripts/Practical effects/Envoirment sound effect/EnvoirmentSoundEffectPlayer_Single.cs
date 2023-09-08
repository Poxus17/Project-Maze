using UnityEngine;

public class EnvoirmentSoundEffectPlayer_Single : MonoBehaviour
{
    [SerializeField] AudioClip audioClip; //audioClip.

    public void PlayAudio()
    {
        MusicMan.instance.PlaySE(audioClip);
    }
}
