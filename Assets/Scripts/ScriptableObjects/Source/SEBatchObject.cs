using UnityEngine;

[CreateAssetMenu(menuName = "SEBatchObject")]
public class SEBatchObject : ScriptableObject
{
    public AudioClip[] audioClips;

    public AudioClip GetRandomAudioClip()
    {
        return audioClips[Random.Range(0, audioClips.Length)];
    }
}