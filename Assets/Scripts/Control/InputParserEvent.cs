using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputParserEvent : MonoBehaviour
{
    public TriggerEventPacket parsedEvent;

    public void ParseInputAsStarted(InputAction.CallbackContext context)
    {
        if (context.started)
            parsedEvent.Invoke();
    }
}
