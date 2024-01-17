using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class UsedAssetsIdentifier : EditorWindow
{
    bool filterMeshes = false;
    bool filterTextures = false;
    bool filterMaterials = false;
    Vector2 scrollPosition = Vector2.zero;
    List<Object> usedAssets = new List<Object>();

    [MenuItem("Tools/Used Assets")]
    public static void ShowWindow()
    {
        GetWindow<UsedAssetsIdentifier>("Used Assets");
    }

    void OnGUI()
    {
        filterMeshes = EditorGUILayout.Toggle("Filter Meshes", filterMeshes);
        filterTextures = EditorGUILayout.Toggle("Filter Textures", filterTextures);
        filterMaterials = EditorGUILayout.Toggle("Filter Materials", filterMaterials);

        if (GUILayout.Button("Find Used Assets"))
        {
            FindUsedAssets();
        }

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        foreach (var asset in usedAssets)
        {
            EditorGUILayout.ObjectField(asset, typeof(Object), false);
        }

        EditorGUILayout.EndScrollView();
    }

    void FindUsedAssets()
    {
        usedAssets.Clear();

        string[] guids = AssetDatabase.FindAssets(""); // this will return all assets

        foreach (var guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);

            if ((filterMeshes && asset is Mesh) ||
                (filterTextures && asset is Texture) ||
                (filterMaterials && asset is Material))
            {
                usedAssets.Add(asset);
            }
        }
    }
}