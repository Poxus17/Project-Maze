using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AiListenerController : MonoBehaviour
{
    [SerializeField] public float range;

    float lastNoiseInput;
    bool noiseLocked = false;

    public void GetNoise(float noiseValue)
    {
        Debug.Log(noiseValue);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(AiListenerController))]
public class EnemyListenerAIEditor : Editor
{
    public void OnSceneGUI()
    {
        var ai = target as AiListenerController;

        // draw the vision cone
        Handles.color = new Color(0.5f, 0.5f, 0, 0.1f);
        Handles.DrawSolidDisc(ai.transform.position, Vector3.up, ai.range);
    }
}
#endif
