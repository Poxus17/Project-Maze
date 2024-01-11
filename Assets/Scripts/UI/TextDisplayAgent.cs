using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextDisplayAgent : MonoBehaviour
{
    [SerializeField] string textToDisplay; // Text to display.
    [SerializeField] float duration; // Duration to display text. -1 for indefinite.
    [SerializeField] InputAction inputAction; // Input action to prematurelqy end text display.

    void Start()
    {
        //Check if input action is set
        if(inputAction==null){
            Debug.Log("I have no action, I am " + gameObject.name);
            return;
        }
        inputAction.performed += KillCommand; // Add kill command to input action.
    }

    public void DisplayText()
    {
        if(textToDisplay.Contains("\\n"))
            textToDisplay = textToDisplay.Replace("\\n", "\n");

        UI_TextDisplay.Instance.DisplayText(textToDisplay, duration);
        inputAction.Enable();
    }

    public void DisplayText(string textToDisplay, float duration)
    {
        UI_TextDisplay.Instance.DisplayText(textToDisplay, duration);
    }

    public void KillCommand(InputAction.CallbackContext context)
    {
        Debug.Log("KillCommand called");
        UI_TextDisplay.Instance.FadeOutText();
        inputAction.Disable();
    }
}
