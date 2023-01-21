using UnityEditor;
using UnityEngine;

public class DecorTransformRandomizerEditor : Editor
{
    [MenuItem("Tools/Randomize Children Position and Rotation")]
    static void Randomize()
    {
        Transform[] children = Selection.activeTransform.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            if (child != Selection.activeTransform)
            {
                child.localPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(0f, 4f), Random.Range(-20f, 20f));
                child.localRotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
            }
        }
    }
}
