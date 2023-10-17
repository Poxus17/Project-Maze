using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    public void Open(int scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void Leave()
    {
        Application.Quit();
    }
}
