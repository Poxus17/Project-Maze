using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class ObjectReplacer : EditorWindow
{
    public GameObject[] objectsToReplace;
    public GameObject replacementPrefab;

    [MenuItem("Tools/Object Replacer")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<ObjectReplacer>("Object Replacer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Replace Settings", EditorStyles.boldLabel);

        // Serialized properties for handling arrays in the Editor
        ScriptableObject target = this;
        SerializedObject serialized = new SerializedObject(target);

        SerializedProperty objectArray = serialized.FindProperty("objectsToReplace");
        EditorGUILayout.PropertyField(objectArray, true);

        replacementPrefab = (GameObject)EditorGUILayout.ObjectField("Replacement Prefab:", replacementPrefab, typeof(GameObject), false);

        serialized.ApplyModifiedProperties();

        if (GUILayout.Button("Replace Objects"))
        {
            ReplaceObjects();
        }
    }

    private void ReplaceObjects()
    {
        if (objectsToReplace.Length == 0 || replacementPrefab == null) return;

        foreach (GameObject obj in objectsToReplace)
        {
            if (obj)
            {
                GameObject newObj = (GameObject)PrefabUtility.InstantiatePrefab(replacementPrefab);
                newObj.transform.position = obj.transform.position;
                newObj.transform.rotation = obj.transform.rotation;
                newObj.transform.localScale = obj.transform.localScale;
                newObj.transform.parent = obj.transform.parent;

                // Optionally keep track of the newly spawned objects in the undo system
                Undo.RegisterCreatedObjectUndo(newObj, "Replace Object");

                // Dispose of the original
                Undo.DestroyObjectImmediate(obj);
            }
        }
    }
}
#endif