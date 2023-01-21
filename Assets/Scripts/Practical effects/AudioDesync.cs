using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDesync : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] float delay;

    // Start is called before the first frame update
    void Start()
    {
        source.loop = true;
        StartCoroutine(playSource());
    }

    IEnumerator playSource()
    {
        yield return new WaitForSeconds(Random.Range(0, delay));
        source.Play();
    }
}
