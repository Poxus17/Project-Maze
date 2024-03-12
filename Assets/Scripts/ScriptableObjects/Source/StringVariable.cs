using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName ="Variables/String Variable")]
public class StringVariable : ScriptableObject
{
    public string value;
    public string defaultValue;

    public void RestoreDefault()
    {
        value = defaultValue;
    } 

    private void OnEnable()
    {
        #if UNITY_EDITOR
        // Subscribe for the "event"
        EditorApplication.playModeStateChanged += ResetValueEditor;
        #endif
    }

    #if UNITY_EDITOR
    void ResetValueEditor(PlayModeStateChange state)
    {
        
        if(state == PlayModeStateChange.ExitingPlayMode)
            value = defaultValue;
        
    }
    #endif
}
