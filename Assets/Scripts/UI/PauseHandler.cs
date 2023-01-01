using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    // Reference to the panel object that contains the pause screen UI
    public GameObject pauseScreenPanel;

    // Method to show the pause screen
    public void ShowPauseScreen()
    {
        // Enable the pause screen panel
        pauseScreenPanel.SetActive(true);

        InputSystemHandler.instance.SetUIMode(true);

        // Set the timeScale to 0 to pause the game
        Time.timeScale = 0;
    }

    // Method to hide the pause screen and resume the game
    public void ResumeGame()
    {
        // Set the timeScale back to 1 to resume the game
        Time.timeScale = 1;

        InputSystemHandler.instance.SetUIMode(false);

        // Disable the pause screen panel
        pauseScreenPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
