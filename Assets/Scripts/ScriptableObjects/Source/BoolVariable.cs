using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[CreateAssetMenu (menuName = "Variables/Bool Variable")]
public class BoolVariable : ScriptableObject
{
    public bool value;
    public bool defaultVal;
    public bool useDefaultValue = true;

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

    public void SetValue(bool val)
    {
        value = val;
    }

#if UNITY_EDITOR
    void ResetValueEditor(PlayModeStateChange state)
    {
        
        if(state == PlayModeStateChange.ExitingPlayMode)
            value = defaultVal;
        
    }
#endif
    void ResetValue(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (useDefaultValue)
            value = defaultVal;
    }

    public void ParseInput(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed)
            value = true;
        else if(context.canceled)
            value = false;
    }

}
