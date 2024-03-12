using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public enum ItemCategory{
    Memory,
    Note,
    Action
}
public class StoreableItem : ScriptableObject
{
    public int itemID = -1;
    public ItemCategory category;
    public string name;
    public Sprite icon;

    public void Copy(StoreableItem item)
    {
        name = item.name;
        icon = item.icon;
        category = item.category;
        itemID = item.itemID;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(StoreableItem), true)]
public class StoreableItemEditor : Editor{
    public override void OnInspectorGUI()
    {
        //Called whenever the inspector is drawn for this object.
        DrawDefaultInspector();

        StoreableItem storeableItem = (StoreableItem)target;

        if(GUILayout.Button("Assign ID")){
            
            string[] guids = AssetDatabase.FindAssets("t:StoreableItem", new[] { "Assets/Scripts/ScriptableObjects/Instances/Past Object Data"});
            var maxID = -1;

            foreach (string guid in guids)
            {
                StoreableItem item = AssetDatabase.LoadAssetAtPath<StoreableItem>(AssetDatabase.GUIDToAssetPath(guid));
                if(item.itemID > maxID)
                    maxID = item.itemID;
            }
            storeableItem.itemID = maxID + 1;
        }
    }
}
#endif