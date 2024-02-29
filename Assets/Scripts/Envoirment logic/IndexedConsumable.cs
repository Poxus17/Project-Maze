using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class IndexedConsumable : MonoBehaviour{

    private static int indexParent = 0;
    [SerializeField] int indexD;

    public int IndexD => indexD;

    #if UNITY_EDITOR
    void Awake(){
        if(indexD == -1)
            Debug.Log("indexD not assigned to " + gameObject.name);
    }
    #endif

    public void RegisterAsConsumed(){
        SaveManager.instance.RegisterConsumable(indexD);
        SaveManager.instance.SaveAbsoluteData();

        Debug.Log("Registered " + gameObject.name + " as consumed");
    }

    public void KillMe(int[] indexes){
        if(indexes.Contains(indexD))
        {
            Debug.Log("Killing " + gameObject.name + " since registered as consumed");
            Destroy(gameObject);
        }
    }

    public static void ResetParentIndex(){
        indexParent = 0;
    }

    public void AssignIndex(){
        indexD = ++indexParent;

        Debug.Log("Assigned indexD " + indexD + " to " + gameObject.name);

        #if UNITY_EDITOR
            PrefabUtility.RecordPrefabInstancePropertyModifications(this);
        #endif
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(IndexedConsumable), true)]
public class IndexedConsumableEditor : Editor{
    public override void OnInspectorGUI()
    {
        //Called whenever the inspector is drawn for this object.
        DrawDefaultInspector();

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        GUILayout.Label("Custom Inspector buttons");

        //This draws the default screen.  You don't need this if you want
        //to start from scratch, but I use this when I'm just adding a button or
        //some small addition and don't feel like recreating the whole inspector.
        if(GUILayout.Button("Set all indexes")){
            var all = FindObjectsOfType<IndexedConsumable>();

            IndexedConsumable.ResetParentIndex();

            for(int i = 0; i < all.Length; i++){
                all[i].AssignIndex();
            }

        }

        if(GUILayout.Button("Ensure index integrity")){
            var all = FindObjectsOfType<IndexedConsumable>();

            var indexes = new List<int>();
            bool integrity = true;

            for(int i = 0; i < all.Length; i++){
                if(indexes.Contains(all[i].IndexD)){
                    Debug.Log("Duplicate indexD found on " + all[i].gameObject.name);
                    integrity = false;
                }
                else
                {
                    indexes.Add(all[i].IndexD);
                }

                if(integrity)
                    Debug.Log("Index integrity is OK");
            }
        }

        if(GUILayout.Button("Assign this indexD")) {
            ((IndexedConsumable)target).AssignIndex();
        }
    }
    
}
#endif
