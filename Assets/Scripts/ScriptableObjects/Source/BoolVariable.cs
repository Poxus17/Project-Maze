using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject
{
    public bool value;
    public bool defaultVal;

    private void OnEnable()
    {
#if UNITY_EDITOR
        // Subscribe for the "event"
        EditorApplication.playModeStateChanged += ResetValue;
#endif
    }

    public void SetNot()
    {
        value = !value;
    }

#if UNITY_EDITOR
    void ResetValue(PlayModeStateChange state)
    {
        if(state == PlayModeStateChange.ExitingPlayMode)
            value = defaultVal;
    }
#endif

}
