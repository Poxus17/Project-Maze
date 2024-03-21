using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

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
                    //Debug.Log("Invoked timer callback " + listener.callbackName);
                }
                catch(Exception e){
                    Debug.LogError("Error invoking timer callback " + listener.callbackName);
                    Debug.LogError(e.Message);
                    Debug.LogError(e.StackTrace);
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

    public void ValidateAllListeners(){
        listeners.RemoveAll(listener => !listener.ValidAction());
    }

    public void PurgeAllListeners(){
        listeners.Clear();
    }

    public void PrintListeners(){
        for(int i = 0; i < listeners.Count; i++){
            Debug.Log("Listener " + i + " has finishes in " + (listeners[i].exitTime - timer) + " seconds, and has callback " + listeners[i].callbackName);
        }
    }

}
class TimerListener{
    protected Action _callback;
    protected float _exitTime;

    public float exitTime => _exitTime;
    public String callbackName => _callback.Method.Name;

    public TimerListener(Action timerAction, float exitTime)
    {
        _callback = timerAction;
        _exitTime = exitTime;
    }

    public void Invoke(){
        _callback();
    }

    public bool ValidAction(){
        return _callback != null;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(GlobalTimerManager), true)]
public class GlobalTimerManagerEditor : Editor{
    public override void OnInspectorGUI()
    {
        //Called whenever the inspector is drawn for this object.
        DrawDefaultInspector();
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        GUILayout.Label("Custom Inspector buttons");

        if(GUILayout.Button("Purge all listeners")){
            var manager = (GlobalTimerManager)target;
            manager.PurgeAllListeners();
        }

        if(GUILayout.Button("Print all listeners")){
            var manager = (GlobalTimerManager)target;
            manager.PrintListeners();
        }

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        GUILayout.Label("Time speed controls");

        if(GUILayout.Button("Dounle time speed")){
            Time.timeScale = 2;
        }

        if(GUILayout.Button("Ultra fast time speed")){
            Time.timeScale = 10;
        }

        if(GUILayout.Button("Half time speed")){
            Time.timeScale = 0.5f;
        }

        if(GUILayout.Button("Normal time speed")){
            Time.timeScale = 1;
        }
    }
}
#endif
