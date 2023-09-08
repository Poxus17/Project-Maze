using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : UIComponent
{

    public override void PersonalEventBindings()
    {
        LaunchComponentPersonalEvents += ShowPauseScreen;
        CloseComponentPersonalEvents += ExitPauseScreen;
    }

    // Method to show the pause screen
    public void ShowPauseScreen()
    {
        // Set the timeScale to 0 to pause the game
        Time.timeScale = 0;
    }

    // Method to hide the pause screen and resume the game
    public void ResumeGame()
    {
        UIManager.Instance.CloseUIComponent();
    }

    public void ExitPauseScreen()
    {
        // Set the timeScale back to 1 to resume the game
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
