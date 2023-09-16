using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCutsceneHandler : MonoBehaviour
{
    bool running = false;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioComponent;
    [SerializeField] float levelLoadStartTimer;

    public void StartRunning()
    {
        if (running)
            return;

        running = true;
        animator.SetTrigger("StartRunning");
        StartCoroutine(TimeToLoad());
        audioComponent.enabled = true;
    }

    IEnumerator TimeToLoad()
    {
        yield return new WaitForSeconds(levelLoadStartTimer);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(2);
    }
}
