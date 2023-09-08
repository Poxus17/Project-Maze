using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartHandler : MonoBehaviour
{
    [SerializeField] AudioClip startClip;
    [SerializeField] GameObject player;

    private void Start()
    {
        MusicMan.instance.PlaySE(startClip);
        StartCoroutine(EndStart());
    }

    IEnumerator EndStart()
    {
        yield return new WaitForSeconds(4.5f);
        player.SetActive(true);
        Destroy(gameObject);
    }

}
