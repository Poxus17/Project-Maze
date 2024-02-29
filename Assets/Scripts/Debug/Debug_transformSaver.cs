using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class Debug_transformSaver : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
}

#if UNITY_EDITOR
[CustomEditor(typeof(Debug_transformSaver))]
public class Debug_transformSaver_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Debug_transformSaver myScript = (Debug_transformSaver)target;
        if (GUILayout.Button("Save Transform"))
        {
            if(!EditorUtility.DisplayDialog("Save Transform", "Please confirm save", "Confirm", "Cancel"))
                return;

            myScript.position = myScript.transform.position;
            myScript.rotation = myScript.transform.rotation;
            myScript.scale = myScript.transform.localScale;
        }

        if(GUILayout.Button("Save position")){
            if(!EditorUtility.DisplayDialog("Save Position", "Please confirm save", "Confirm", "Cancel"))
                return;

            myScript.position = myScript.transform.position;
        }

        if(GUILayout.Button("Save rotation")){

            if(!EditorUtility.DisplayDialog("Save Rotation", "Please confirm save", "Confirm", "Cancel"))
                return;

            myScript.rotation = myScript.transform.rotation;
        }

        if(GUILayout.Button("Save scale")){

            if(!EditorUtility.DisplayDialog("Save Scale", "Please confirm save", "Confirm", "Cancel"))
                return;

            myScript.scale = myScript.transform.localScale;
        }

        if(GUILayout.Button("Restore transform")){
            myScript.transform.position = myScript.position;
            myScript.transform.rotation = myScript.rotation;
            myScript.transform.localScale = myScript.scale;
        }

        if(GUILayout.Button("Restore position")){
            myScript.transform.position = myScript.position;
        }

        if(GUILayout.Button("Restore rotation")){
            myScript.transform.rotation = myScript.rotation;
        }

        if(GUILayout.Button("Restore scale")){
            myScript.transform.localScale = myScript.scale;
        }
    }
}
#endif // UNITY_EDITOR