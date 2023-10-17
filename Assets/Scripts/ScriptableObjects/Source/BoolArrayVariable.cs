using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class BoolArrayVariable : ScriptableObject
{
    public bool[] value;

    private void OnEnable()
    {
#if UNITY_EDITOR
        // Subscribe for the "event"
        EditorApplication.playModeStateChanged += ResetValue;
#endif
    }

#if UNITY_EDITOR
    void ResetValue(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
            value = new bool[value.Length];
    }
#endif
}
