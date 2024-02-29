using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantComponent : MonoBehaviour
{
    [SerializeField] string persistanceTag = "Generic"; //Must be changed in editor, or it'll cause an error.
    [SerializeField] TriggerEventPacket onGameSceneLoaded;

    private static List<PersistantID> _persistantTags = new List<PersistantID>();
    private void Awake(){

        if(persistanceTag == "Generic"){
            Debug.LogError("Persistant tag not set for " + gameObject.name + ". Please set a tag in the editor.");
            return;
        }

        foreach(PersistantID persistant in _persistantTags){
            if(persistant.id == persistanceTag){
                if(persistant.component != null && persistant.component != this)
                {
                    
                    Destroy(gameObject);
                    return;
                }
                    
            }
        }

        
        _persistantTags.Add(new PersistantID(this, persistanceTag));
        DontDestroyOnLoad(gameObject);
        Debug.Log("Persistant component " + persistanceTag + " registered.");
    }

    private void Start(){
        PersistantManager.instance.RegisterPersistantComponent(this);
    }


    public void OnDestroy(){
        _persistantTags.RemoveAll(persistant => persistant.component == this);
    }

    public void OnGameSceneLoaded(){
        onGameSceneLoaded.Invoke();
    }
}

class PersistantID{
    private string _id;
    public string id => _id;

    private PersistantComponent _component;
    public PersistantComponent component => _component;

    public PersistantID(PersistantComponent component, string id){
        _component = component;
        _id = id;
    }

    public void SetComponent(PersistantComponent component){
        _component = component;
    }

}
