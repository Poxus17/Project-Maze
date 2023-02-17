using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontAudioLerp : MonoBehaviour
{
    public AudioSource audioSource;
    public float maxVolume = 1.0f;
    public float minVolume = 0.0f;
    public float minDistance = 10.0f;
    public float maxDistance = 20.0f;
    public float frontBuffer = 0.0f;

    bool allowedLerp;

    Transform otherT;


    void Start()
    {

    }

    void Update()
    {
        if (allowedLerp)
        {
            float distance = Vector3.Distance(audioSource.transform.position, otherT.position);
            float lerpValue = Mathf.InverseLerp(minDistance, maxDistance, distance);
            audioSource.volume = Mathf.Lerp(minVolume, maxVolume, 1-lerpValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "MainCamera")
            return;

        if (other.transform.position.z < transform.position.z)
            return;

        otherT = other.transform;        
        allowedLerp = true;
        audioSource.gameObject.SetActive(allowedLerp);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "MainCamera")
            return;

        allowedLerp = false;
        audioSource.gameObject.SetActive(allowedLerp);
    }

}
