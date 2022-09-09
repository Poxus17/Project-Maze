using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PastObjectManager : MonoBehaviour, IInteractable
{
    [SerializeField] PastObjectData pastObjectData;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        audioSource.clip = pastObjectData.clip;
        audioSource.Play();
    }
}
