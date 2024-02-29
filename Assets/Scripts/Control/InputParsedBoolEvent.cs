using UnityEngine;
using UnityEngine.InputSystem;

public class InputParsedBoolEvent : InputParserEvent
{
    [SerializeField] BoolVariable boolVariable; //bool variable.

    public void ParseInputAsHold(InputAction.CallbackContext context)
    {
        if (context.performed){
            boolVariable.value = true;
            parsedEvent.Invoke();
        }
        else if (context.canceled){
            boolVariable.value = false;
            parsedEvent.Invoke();
        }
    }
}
