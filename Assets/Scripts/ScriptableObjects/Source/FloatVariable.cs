using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Variables/Float Variable")]
public class FloatVariable : ScriptableObject
{
    public float value;
    public float defaultVal;

    public void SetValue(float value)
    {
        this.value = value;
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
            value = defaultVal;
        
    }
    #endif
}
