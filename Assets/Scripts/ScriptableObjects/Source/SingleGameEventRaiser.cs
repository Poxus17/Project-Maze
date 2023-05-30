using System.Collections;
using UnityEngine;

public class SingleGameEventRaiser : MonoBehaviour
{
    [SerializeField] GameEvent raiseEvent;

    public void RaiseEvent(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(context.started)
            raiseEvent.Raise();
    }

    public void RaiseEventByTimer(float time)
    {
        StartCoroutine(EventTimer(time));
    }

    private IEnumerator EventTimer(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        raiseEvent.Raise();
    }
}
