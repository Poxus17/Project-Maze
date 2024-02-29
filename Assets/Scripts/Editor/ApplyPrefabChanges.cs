using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ApplyPrefabChanges : EditorWindow
{
    [MenuItem("Tools/Apply Prefab Changes (Including Children)")]
    static void ApplyChangesIncludingChildren()
    {
        // Ensure a GameObject is selected
        if (Selection.activeGameObject == null)
        {
            Debug.LogWarning("Please select a GameObject to apply prefab changes.");
            return;
        }

        GameObject selectedGameObject = Selection.activeGameObject;
        ApplyPrefabChangesRecursively(selectedGameObject);

        Debug.Log("Prefab changes applied to selected GameObject and its children.");
    }

    static void ApplyPrefabChangesRecursively(GameObject gameObject)
    {
        // Apply changes to the current gameObject if it's a prefab instance
        if (PrefabUtility.IsPartOfPrefabInstance(gameObject))
        {
            PrefabUtility.ApplyPrefabInstance(gameObject, InteractionMode.UserAction);
        }

        // Recursively apply changes to all children
        foreach (Transform child in gameObject.transform)
        {
            ApplyPrefabChangesRecursively(child.gameObject);
        }
    }
}
