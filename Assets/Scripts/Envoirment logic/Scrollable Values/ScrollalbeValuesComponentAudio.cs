using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ScrollalbeValuesComponentAudio : ScrollalbeValuesComponent
{
    [SerializeField] AudioClip[] audioClips;

    private AudioSource audioSource;

    private void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    protected override void ApplyScroll(){
        if(audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = audioClips[Index];
        audioSource.Play();
    }
}
