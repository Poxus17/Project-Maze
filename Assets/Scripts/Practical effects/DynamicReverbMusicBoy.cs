using UnityEngine;
using UnityEngine.Audio;

public class DynamicReverbMusicBoy : MonoBehaviour
{
    [SerializeField] float maxDistance;

    private AudioSource audioSource;
    private AudioReverbFilter reverbFilter;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        reverbFilter = GetComponent<AudioReverbFilter>();
    }

    public void PlayClipWithReverb(AudioClip clip, float distance)
    {
        var dryLevel = Mathf.Lerp(0, -2500, (distance / maxDistance));
        reverbFilter.dryLevel = dryLevel;
        audioSource.PlayOneShot(clip);
    }
}
