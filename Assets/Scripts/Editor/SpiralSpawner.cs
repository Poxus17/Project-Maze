using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

#if UNITY_EDITOR
public class SpiralSpawner : EditorWindow
{
    public GameObject[] objectsToSpawn;
    public float bottomRadius = 1f;
    public float topRadius = 5f;
    public float spiralHeight = 5f;
    public int initialAmount = 10;
    public bool randomRotation = false;

    private List<GameObject> lastSpawnedObjects = new List<GameObject>();
    private int spawnDaddyIndex = 0;

    [MenuItem("Tools/Spiral Spawner")]
    public static void ShowWindow()
    {
        GetWindow<SpiralSpawner>("Spiral Spawner");
    }

    private void OnGUI()
    {
        GUILayout.Label("Objects to Spawn", EditorStyles.boldLabel);
        ScriptableObject target = this;
        SerializedObject so = new SerializedObject(target);
        SerializedProperty objectsProperty = so.FindProperty("objectsToSpawn");
        EditorGUILayout.PropertyField(objectsProperty, true);
        so.ApplyModifiedProperties();

        bottomRadius = EditorGUILayout.FloatField("Bottom Radius", bottomRadius);
        topRadius = EditorGUILayout.FloatField("Top Radius", topRadius);
        spiralHeight = EditorGUILayout.FloatField("Spiral Height", spiralHeight);
        initialAmount = EditorGUILayout.IntField("Initial Amount", initialAmount);
        randomRotation = EditorGUILayout.Toggle("Random Rotation", randomRotation);

        if (GUILayout.Button("Spawn"))
        {
            SpawnObjects();
        }

        if (GUILayout.Button("Undo Last Spawn"))
        {
            UndoLastSpawn();
        }
    }

    private void SpawnObjects()
    {
        // Create a parent for the new spawn
        GameObject spawnDaddy = new GameObject($"Spawn daddy {spawnDaddyIndex++}");
        lastSpawnedObjects.Add(spawnDaddy); // add parent to the list to ensure it can be deleted by undo

        for (int i = 0; i < initialAmount; i++)
        {
            float t = (float)i / initialAmount;
            float currentRadius = Mathf.Lerp(bottomRadius, topRadius, t);
            float angle = 2 * Mathf.PI * t;
            float x = currentRadius * Mathf.Cos(angle);
            float z = currentRadius * Mathf.Sin(angle);
            float y = t * spiralHeight;

            GameObject prefab = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            GameObject obj = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            obj.transform.position = new Vector3(x, y, z);
            obj.transform.parent = spawnDaddy.transform;

            if (randomRotation)
            {
                obj.transform.rotation = Quaternion.Euler(
                    Random.Range(0f, 360f),
                    Random.Range(0f, 360f),
                    Random.Range(0f, 360f)
                );
            }

            lastSpawnedObjects.Add(obj);
        }
    }

    private void UndoLastSpawn()
    {
        foreach (GameObject obj in lastSpawnedObjects)
        {
            DestroyImmediate(obj);
        }

        lastSpawnedObjects.Clear();
    }
}
#endif