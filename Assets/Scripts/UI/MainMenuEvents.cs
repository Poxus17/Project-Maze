using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    public void Open()
    {
        PersistantManager.instance.LoadSceneAction();
    }

    public void Leave()
    {
        Application.Quit();
    }
}
