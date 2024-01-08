using UnityEngine;
using UnityEditor;

public class LightSettingsTool : EditorWindow
{
    private LightType selectedLightType = LightType.Point;
    private LightmapBakeType selectedLightmapBakeType = LightmapBakeType.Realtime;

    [MenuItem("Tools/Light Settings Tool")]
    public static void ShowWindow()
    {
        GetWindow<LightSettingsTool>("Light Settings Tool");
    }

    private void OnGUI()
    {
        GUILayout.Label("Set Light Properties", EditorStyles.boldLabel);

        // Light Type ComboBox
        selectedLightType = (LightType)EditorGUILayout.EnumPopup("Light Type", selectedLightType);

        // Light Mode ComboBox
        selectedLightmapBakeType = (LightmapBakeType)EditorGUILayout.EnumPopup("Light Mode", selectedLightmapBakeType);

        // Apply Button
        if (GUILayout.Button("Apply to Selected Lights"))
        {
            ApplySettingsToSelectedLights();
        }
    }

    private void ApplySettingsToSelectedLights()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            ApplySettingsToLightComponents(obj);
        }
    }

    private void ApplySettingsToLightComponents(GameObject obj)
    {
        Light light = obj.GetComponent<Light>();
        if (light != null && light.renderingLayerMask != 0) // Check if the light's culling mask is not set to 'Nothing'
        {
            light.type = selectedLightType;
            light.lightmapBakeType = selectedLightmapBakeType;
            EditorUtility.SetDirty(light); // Mark the light as dirty to register the change
        }

        // Recursive call for each child of the current GameObject
        foreach (Transform child in obj.transform)
        {
            ApplySettingsToLightComponents(child.gameObject);
        }
    }
}
