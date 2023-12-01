using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject
{
    public bool value;
    public bool defaultVal;

    private void OnEnable()
    {
#if UNITY_EDITOR
        // Subscribe for the "event"
        EditorApplication.playModeStateChanged += ResetValueEditor;
#endif

        SceneManager.sceneLoaded += ResetValue;
    }

    public void SetNot()
    {
        value = !value;
    }

#if UNITY_EDITOR
    void ResetValueEditor(PlayModeStateChange state)
    {
        /*
        if(state == PlayModeStateChange.ExitingPlayMode)
            value = defaultVal;
        */
    }
#endif
    void ResetValue(Scene scene, LoadSceneMode loadSceneMode)
    {
        value = defaultVal;
    }

}
