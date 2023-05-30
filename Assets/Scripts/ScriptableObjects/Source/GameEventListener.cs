using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public UnityEvent Response;
    public float raiseTimer = 0;
    public bool oneFrameDelay;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }
    public void OnEventRaised() 
    { StartCoroutine(RaiseTimer()); }

    private IEnumerator RaiseTimer()
    {
        yield return 
            (oneFrameDelay ? 
            null : new WaitForSecondsRealtime(raiseTimer)
            );

        Response.Invoke();
    }

}
