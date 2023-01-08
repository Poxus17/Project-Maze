using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityManager : MonoBehaviour
{
    [SerializeField] float fullSanity;
    [SerializeField] float drainRate; //per second
    [SerializeField] float refillRate; //per second
    [SerializeField] float refillCooldown; // How long pause between exposure end and regain begin
    [SerializeField] float minVolume;
    [SerializeField] float maxVolume;
    [SerializeField] float minPitch;
    [SerializeField] float maxPitch;
    [SerializeField] BoolVariable compassUp;
    [SerializeField] AudioSource audioSource; // AudioSource.

    float sanity;

    // Start is called before the first frame update
    void Start()
    {
        sanity = fullSanity;
    }

    // Update is called once per frame
    void Update()
    {
        if (compassUp.value && sanity > 0)
        {
            sanity -= drainRate * Time.deltaTime;
        }
        else if(sanity < fullSanity)
        {
            sanity += refillRate * Time.deltaTime;
        }

        audioSource.volume = Mathf.Lerp(minVolume, maxVolume, (1 - (sanity/fullSanity)) );

        //Debug.Log("Sanity - " + sanity + " | Sanity ratio - " + (1 - (sanity / fullSanity)));
        //audioSource.pitch = Mathf.Lerp(minPitch, maxPitch, (1 - (sanity / fullSanity)) );
    }
}
