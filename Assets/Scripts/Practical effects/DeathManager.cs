using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    [SerializeField] VideoPlayer player;


    private void Start()
    {
        player.Prepare();
        player.targetTexture.Release();
    }

    public void ActivateJumpscare()
    {
        gameObject.SetActive(true);
        player.Play();
        player.loopPointReached += Restart;
    }

    public void Restart(UnityEngine.Video.VideoPlayer vp)
    {
        //Application.Quit();
        SceneManager.LoadScene(1);
    }

}
