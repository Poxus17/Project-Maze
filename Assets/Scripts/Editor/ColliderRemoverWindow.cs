using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class ColliderRemoverWindow : EditorWindow
{
    public GameObject[] gameObjectsToRemoveCollidersFrom;

    [MenuItem("Tools/Collider Remover")]
    public static void ShowWindow()
    {
        GetWindow<ColliderRemoverWindow>("Collider Remover");
    }

    void OnGUI()
    {
        GUILayout.Label("Remove Colliders", EditorStyles.boldLabel);

        SerializedObject serializedObject = new SerializedObject(this);
        SerializedProperty serializedProperty = serializedObject.FindProperty("gameObjectsToRemoveCollidersFrom");
        EditorGUILayout.PropertyField(serializedProperty, true);
        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Remove Colliders"))
        {
            foreach (GameObject go in gameObjectsToRemoveCollidersFrom)
            {
                if (go)
                {
                    Collider[] colliders = go.GetComponentsInChildren<Collider>();
                    foreach (Collider collider in colliders)
                    {
                        DestroyImmediate(collider);
                    }
                }
            }
        }
    }
}

#endif