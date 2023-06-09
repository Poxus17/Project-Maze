using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    [SerializeField] float timeToRestart;
    public void ActivateJumpscare()
    {
        StartCoroutine(TimeDown());
    }

    IEnumerator TimeDown()
    {
        yield return new WaitForSecondsRealtime(timeToRestart);
        Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

}
