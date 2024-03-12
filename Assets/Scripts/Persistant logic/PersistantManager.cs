using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistantManager : MonoBehaviour
{
    [SerializeField] IntVariable sceneToLoad;
    [SerializeField] GameEvent deathLoadEvent;
    [SerializeField] int loadSceneIndex;

    /*public delegate void LoadingStateChanged(bool isLoading);
    public event LoadingStateChanged OnLoadingStateChanged;*/

    private bool isLoading = false;
    public bool IsLoading => isLoading;

    public int ActiveSceneIndex => SceneManager.GetActiveScene().buildIndex;

    private List<PersistantComponent> persistantComponents;

    #region Singleton & Persistant
    public static PersistantManager instance;
    private void Awake(){

        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(this);
        }

        persistantComponents = new List<PersistantComponent>();
    }

    private void Start(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnDestroy(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
#endregion

    public void RegisterPersistantComponent(PersistantComponent persistantComponent){
        persistantComponents.Add(persistantComponent);
        persistantComponents.Sort((x, y) => x.priority.CompareTo(y.priority));
    }

    public void ReloadScene(){
        LoadScene(ActiveSceneIndex);
    }

    public void LoadScene(int sceneIndex, bool stealthLoad = false){
        
        /*if(OnLoadingStateChanged != null)
            OnLoadingStateChanged(true);*/
        isLoading = true;

        sceneToLoad.value = sceneIndex;
        FadeManager.instance.Fade(true, stealthLoad ? LoadDirectly : LoadSceneAction);
    }

    public void LoadDirectly(){
        SceneManager.LoadScene(sceneToLoad.value);
    }

    public void LoadSceneAction(){
        SceneManager.LoadScene(loadSceneIndex);
    }

    public void MidLoadSceneSet(int sceneToLoad){
        this.sceneToLoad.SetValue(sceneToLoad);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){

        /*if(OnLoadingStateChanged != null)
            OnLoadingStateChanged(false);*/
        isLoading = false;

        if(scene.buildIndex == loadSceneIndex){
            Debug.Log("Detected load scene. Preparing data");

            if(LoadFlags.deathLoad)
                deathLoadEvent.Raise();
        }
        else{
            foreach(PersistantComponent component in persistantComponents){
                try{
                    component.OnGameSceneLoaded();
                }
                catch(System.Exception e){
                    Debug.LogError("Caught error while calling OnGameSceneLoaded in persistant manager. Error: " + e.Message);
                }
                
            }
        }
    }
}
