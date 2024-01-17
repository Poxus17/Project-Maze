using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EditorLightController : EditorWindow
{
    GameObject lightObject;

    [MenuItem("Tools/Editor Light")]
    public static void ShowWindow()
    {
        GetWindow<EditorLightController>("Editor light");
    }

    void OnGUI()
    {
        lightObject = (GameObject)EditorGUILayout.ObjectField(lightObject, typeof(GameObject), true);

        if (GUILayout.Button("Move to me"))
            AlignWithView(lightObject);
    }

    void AlignWithView(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogError("Object is null");
            return;
        }

        if (SceneView.lastActiveSceneView == null)
        {
            Debug.LogError("No active SceneView");
            return;
        }

        // Get the current view transform from the last active SceneView
        Transform viewTransform = SceneView.lastActiveSceneView.camera.transform;

        // Align the object with the view
        obj.transform.position = viewTransform.position;
        obj.transform.rotation = viewTransform.rotation;
    }
}
