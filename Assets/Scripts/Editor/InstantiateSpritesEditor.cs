using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class InstantiateSpritesEditor : EditorWindow
{
    private Canvas targetCanvas;
    private string spritesFolderPath = "Assets/Sprites"; // Default path; adjust as needed

    [MenuItem("Tools/Instantiate Sprites on Canvas")]
    public static void ShowWindow()
    {
        GetWindow<InstantiateSpritesEditor>("Instantiate Sprites");
    }

    private void OnGUI()
    {
        GUILayout.Label("Instantiate Sprites on Canvas", EditorStyles.boldLabel);

        targetCanvas = EditorGUILayout.ObjectField("Target Canvas", targetCanvas, typeof(Canvas), true) as Canvas;

        // Folder path for sprites
        spritesFolderPath = EditorGUILayout.TextField("Sprites Folder Path", spritesFolderPath);

        if (GUILayout.Button("Load Sprites & Instantiate"))
        {
            LoadSpritesAndInstantiate();
        }
    }

    private void LoadSpritesAndInstantiate()
    {
        if (targetCanvas == null)
        {
            Debug.LogError("Target Canvas is not set.");
            return;
        }

        // Ensure the folder path is not empty and exists
        if (string.IsNullOrEmpty(spritesFolderPath) || !System.IO.Directory.Exists(spritesFolderPath))
        {
            Debug.LogError("The specified folder path does not exist.");
            return;
        }

        string[] files = System.IO.Directory.GetFiles(spritesFolderPath, "*.png", System.IO.SearchOption.AllDirectories);
        List<Sprite> loadedSprites = new List<Sprite>();

        foreach (string file in files)
        {
            string assetPath = file.Replace(System.IO.Path.DirectorySeparatorChar, '/').Replace(Application.dataPath, "Assets");
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
            if (sprite != null)
            {
                loadedSprites.Add(sprite);
            }
        }

        if (loadedSprites.Count == 0)
        {
            Debug.LogError("No sprites found in the specified folder.");
            return;
        }

        foreach (Sprite sprite in loadedSprites)
        {
            GameObject newImageObj = new GameObject(sprite.name);
            newImageObj.transform.SetParent(targetCanvas.transform, false);
            Image imageComponent = newImageObj.AddComponent<Image>();
            imageComponent.sprite = sprite;
            RectTransform rectTransform = newImageObj.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero; // Adjust as needed
        }

        Debug.Log($"Instantiated {loadedSprites.Count} sprites as UI Images on the Canvas.");
    }
}
