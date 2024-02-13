using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GlobalTimerManager : MonoBehaviour
{
    
    private bool isRunning;
    private float timer = 0;
    private List<TimerListener> listeners;

    public static GlobalTimerManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        listeners = new List<TimerListener>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRunning)
            return;

        timer += Time.deltaTime;

        foreach(TimerListener listener in listeners.ToArray()){
            if(listener.exitTime <= timer){
                try{
                    listener.Invoke();
                }
                catch{
                    if(!listener.ValidAction())
                        listeners.Remove(listener);
                }
                
                listeners.Remove(listener);
            }
        }

        if(listeners.Count <= 0)
        {
            isRunning = false;
            timer = 0;
        }
    }

    public void RegisterForTimer(Action callback, float duration){
        listeners.Add(new TimerListener(callback, timer + duration));
        isRunning = true;
    }

    public void PurgeAllListeners(){
        listeners.Clear();
    }
}


class TimerListener{
    protected Action _callback;
    protected float _exitTime;

    public float exitTime => _exitTime;

    public TimerListener(Action timerAction, float exitTime)
    {
        _callback = new Action(timerAction);
        _exitTime = exitTime;
    }

    public void Invoke(){
        _callback();
    }

    public bool ValidAction(){
        return _callback != null;
    }
}
