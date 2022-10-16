using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    [SerializeField] VideoPlayer player;

    public void ActivateJumpscare()
    {
        gameObject.SetActive(true);
        player.Play();
        player.loopPointReached += Restart;
    }

    public void Restart(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(0);
    }

}
