using UnityEngine;
using UnityEngine.InputSystem;

public class TextDisplayAgent : MonoBehaviour
{
    [SerializeField] string textToDisplay; // Text to display.
    [SerializeField] float duration; // Duration to display text. -1 for indefinite.
    [SerializeField] InputAction inputAction; // Input action to prematurelqy end text display.
    [SerializeField] InputAction launchAction; // Input action to launch text display.

    void Start()
    {
        //Check if input action is set
        if(inputAction==null){
            Debug.Log("I have no action, I am " + gameObject.name);
            return;
        }
        inputAction.performed += KillCommand; // Add kill command to input action.
    }

    public void BindLaucnhAction(){

        if(launchAction==null){
            Debug.Log("Trying to bind null action. I am " + gameObject.name);
            return;
        }

        launchAction.performed += DisplayTextAction;
        launchAction.Enable();
    }

    public void DisplayText()
    {
        if(textToDisplay.Contains("\\n"))
            textToDisplay = textToDisplay.Replace("\\n", "\n");

        UI_TextDisplay.Instance.DisplayText(textToDisplay, duration);
        inputAction.Enable();
    }

    private void DisplayTextAction(InputAction.CallbackContext context){
        DisplayText();
    }

    public void DisplayText(string textToDisplay, float duration)
    {
        UI_TextDisplay.Instance.DisplayText(textToDisplay, duration);
    }

    public void KillCommand(InputAction.CallbackContext context)
    {
        UI_TextDisplay.Instance.FadeOutText();
        inputAction.Disable();
        launchAction.Disable();
    }

    private void OnDestroy()
    {
        inputAction.performed -= KillCommand;
        launchAction.performed -= DisplayTextAction;

        //UI_TextDisplay.Instance.FadeOutText();
        inputAction.Disable();
        launchAction.Disable();
    }
}
