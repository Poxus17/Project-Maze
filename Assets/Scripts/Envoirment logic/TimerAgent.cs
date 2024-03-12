using UnityEngine;
using UnityEngine.Events;

public class TimerAgent : MonoBehaviour
{
    [SerializeField] float timerDuration;
    [SerializeField] UnityEvent onTimerEnd;
    public void CallTimer(){
        GlobalTimerManager.instance.RegisterForTimer(onTimerEnd.Invoke, timerDuration);
    }
}
