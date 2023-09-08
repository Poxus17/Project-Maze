using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    public void Open()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Leave()
    {
        Application.Quit();
    }
}
