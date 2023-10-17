using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

#if UNITY_EDITOR
public class RectangleSpawner : EditorWindow
{
    // Object parameters
    public GameObject[] objectsToSpawn;
    public int objectCount = 10;
    public bool randomRotation = false;
    public bool randomScale = false;
    public Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 maxScale = new Vector3(1.5f, 1.5f, 1.5f);

    // Rectangle parameters from BoxCollider
    public BoxCollider spawnBounds;

    // Internal tracking for undo
    private List<GameObject> lastSpawnedObjects = new List<GameObject>();
    private int spawnIndex = 0;

    [MenuItem("Tools/Rectangle Spawner")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<RectangleSpawner>("Rectangle Spawner");
    }

    private void OnGUI()
    {
        // Object parameters
        GUILayout.Label("Objects Settings", EditorStyles.boldLabel);
        ScriptableObject target = this;
        SerializedObject serialized = new SerializedObject(target);
        SerializedProperty objectArray = serialized.FindProperty("objectsToSpawn");
        EditorGUILayout.PropertyField(objectArray, true);
        serialized.ApplyModifiedProperties();

        objectCount = EditorGUILayout.IntField("Object Count:", objectCount);
        randomRotation = EditorGUILayout.Toggle("Random Rotation:", randomRotation);
        randomScale = EditorGUILayout.Toggle("Random Scale:", randomScale);
        minScale = EditorGUILayout.Vector3Field("Min Scale:", minScale);
        maxScale = EditorGUILayout.Vector3Field("Max Scale:", maxScale);

        // Rectangle parameters from BoxCollider
        GUILayout.Label("Rectangle Settings", EditorStyles.boldLabel);
        spawnBounds = (BoxCollider)EditorGUILayout.ObjectField("Spawn Bounds:", spawnBounds, typeof(BoxCollider), true);

        // Buttons
        if (GUILayout.Button("Spawn Objects"))
        {
            SpawnObjectsInRectangle();
        }

        if (GUILayout.Button("Undo Last Spawn"))
        {
            UndoLastSpawn();
        }
    }

    private void SpawnObjectsInRectangle()
    {
        if (objectsToSpawn.Length == 0 || !spawnBounds) return;

        GameObject spawnDaddy = new GameObject("rectSpawnDaddy" + spawnIndex++);
        lastSpawnedObjects.Add(spawnDaddy);

        for (int i = 0; i < objectCount; i++)
        {
            GameObject obj = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], spawnDaddy.transform);
            obj.transform.position = new Vector3(
                Random.Range(spawnBounds.bounds.min.x, spawnBounds.bounds.max.x),
                Random.Range(spawnBounds.bounds.min.y, spawnBounds.bounds.max.y),
                Random.Range(spawnBounds.bounds.min.z, spawnBounds.bounds.max.z)
            );

            if (randomRotation)
            {
                obj.transform.rotation = Quaternion.Euler(
                    Random.Range(0f, 360f),
                    Random.Range(0f, 360f),
                    Random.Range(0f, 360f)
                );
            }

            if (randomScale)
            {
                obj.transform.localScale = new Vector3(
                    Random.Range(minScale.x, maxScale.x),
                    Random.Range(minScale.y, maxScale.y),
                    Random.Range(minScale.z, maxScale.z)
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