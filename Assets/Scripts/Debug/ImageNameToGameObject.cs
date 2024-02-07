using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

// This script can stay empty or be used for other purposes related to the GameObject.
public class ImageNameToGameObject : MonoBehaviour
{
    // Reference to the Image component
    public Image imageComponent;
}

#if UNITY_EDITOR
[CustomEditor(typeof(ImageNameToGameObject))]
public class ImageNameToGameObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Draws the default inspector

        ImageNameToGameObject script = (ImageNameToGameObject)target;

        if (GUILayout.Button("Update GameObject Name"))
        {
            if (script.imageComponent != null && script.imageComponent.sprite != null)
            {
                // Set the GameObject's name to the sprite's name
                script.gameObject.name = script.imageComponent.sprite.name;
                Debug.Log("GameObject name updated to: " + script.gameObject.name);
            }
            else
            {
                Debug.LogWarning("Image component or sprite is missing.");
            }
        }
    }
}
#endif
