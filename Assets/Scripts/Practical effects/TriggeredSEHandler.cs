using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredSEHandler : MonoBehaviour
{
    public SEBatchObject clipBatch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MusicMan.instance.PlaySE(clipBatch.GetRandomAudioClip());

        }
    }
}
