using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AiListenerController : MonoBehaviour
{
    [SerializeField] public float range;
    [SerializeField] float certainThreshold;
    [SerializeField] float uncertainRangeMultiplier;

    float lastNoiseInput;
    bool noiseLocked = false;

    public delegate void NoticeNoise();
    public static event NoticeNoise OnNoticeNoise;

    public void GetNoise(float noiseValue)
    {
        if (noiseValue < 0)
            return;
        else if(noiseValue < certainThreshold)
        {
            var uncertainDelta = certainThreshold - noiseValue;
            var randomValue = (int)Random.Range(0, uncertainDelta * uncertainRangeMultiplier);

            if(randomValue != 1)
            {
                return;
            }
        }

        Debug.Log("I HEAR YOU");
        OnNoticeNoise();
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
