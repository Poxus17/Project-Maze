using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    [SerializeField] float timeToRestart;
    [SerializeField] int restartLevelIndex = 4;
    public void ActivateJumpscare()
    {
        LoadFlags.deathLoad = true;
        GlobalTimerManager.instance.RegisterForTimer(() => {PersistantManager.instance.ReloadScene();}, timeToRestart);
    }
}
