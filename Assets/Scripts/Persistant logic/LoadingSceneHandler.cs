using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LoadingSceneHandler : MonoBehaviour
{
    [SerializeField] IntVariable sceneToLoad;

    private void Start(){
        StartCoroutine(WaitForLoadingScreen());
    }

    private IEnumerator WaitForLoadingScreen(){
        yield return new WaitForFixedUpdate();
        LoadNextScene();
    }

    public void LoadNextScene(){
        if(sceneToLoad.value < 0){
            Debug.LogError("Scene to load not set for " + gameObject.name + ". Please set a scene in the editor.");
            return;
        }
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneToLoad.value);
    }
}
