using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SingleGameEventRaiser : MonoBehaviour
{
    [SerializeField] GameEvent raiseEvent;

    public void RaiseEvent(InputAction.CallbackContext context)
    {
        if(context.started)
            raiseEvent.Raise();
    }

    public void RaiseEventInstant()
    {
        raiseEvent.Raise();
    }

    public void RaiseEventByTimer(float time)
    {
        StartCoroutine(EventTimer(time));
    }

    public void RaiseEventConditioned(BoolVariable condition)
    {
        if (condition.value)
            raiseEvent.Raise();
    }

    private IEnumerator EventTimer(float time)
    {
        yield return new WaitForSeconds(time);
        raiseEvent.Raise();
    }
}
