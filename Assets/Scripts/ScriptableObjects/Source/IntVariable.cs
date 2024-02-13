using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Variables/Int Variable")]
public class IntVariable : ScriptableObject
{
    public int value;
    public int defaultVal;

    public void SetValue(int value)
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