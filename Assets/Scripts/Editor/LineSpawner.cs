using UnityEngine;
using UnityEditor;
using System;

public class LineSpawner : EditorWindow
{
    GameObject anchor;
    bool cloneX = true;
    bool cloneY = false;
    bool cloneZ = false;
    float spacing = 1.0f;
    int instanceCount = 1;
    bool reverseMode = false;

    [MenuItem("Tools/Line Spawner")]
    public static void ShowWindow()
    {
        GetWindow<LineSpawner>("Line Spawner");
    }

    void OnGUI()
    {
        GUILayout.Label("Spawn Settings", EditorStyles.boldLabel);
        anchor = (GameObject)EditorGUILayout.ObjectField("Anchor", anchor, typeof(GameObject), true);
        
        cloneX = EditorGUILayout.Toggle("Clone in X Axis", cloneX);
        cloneY = EditorGUILayout.Toggle("Clone in Y Axis", cloneY);
        cloneZ = EditorGUILayout.Toggle("Clone in Z Axis", cloneZ);

        spacing = EditorGUILayout.FloatField("Spacing", spacing);
        instanceCount = EditorGUILayout.IntField("Instance Count", instanceCount);
        reverseMode = EditorGUILayout.Toggle("Reverse Mode", reverseMode);

        if (GUILayout.Button("Clone"))
        {
            CloneObjects();
        }
    }

    void CloneObjects()
    {
        if (anchor == null)
        {
            Debug.LogError("Anchor is not set.");
            return;
        }

        // Generate a unique identifier for the parent of clones
        string uniqueID = "#" + UnityEngine.Random.Range(1000, 10000).ToString();
        GameObject clonesParent = new GameObject("Clone daddy" + uniqueID);
        Undo.RegisterCreatedObjectUndo(clonesParent, "Create Clone Parent");

        Vector3 direction = new Vector3(cloneX ? 1 : 0, cloneY ? 1 : 0, cloneZ ? 1 : 0) * (reverseMode ? -1 : 1);

        for (int i = 1; i <= instanceCount; i++)
        {
            Vector3 spawnPosition = anchor.transform.position + direction * spacing * i;
            GameObject clone = Instantiate(anchor, spawnPosition, anchor.transform.rotation);
            clone.transform.SetParent(clonesParent.transform, true);
            clone.name = anchor.name + "_Clone_" + i;
            Undo.RegisterCreatedObjectUndo(clone, "Create " + clone.name);
        }
    }
}
