using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistantDataSender : MonoBehaviour
{
    [SerializeField] BoolVariable loadOccured;
    [SerializeField] Vector3Variable playerPosition;

    private string persistantMessege = "No persistant messege";
    private int initialSceneIndex;
    private static PersistantDataSender instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            initialSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    private void Start(){
        DebugMessage();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        loadOccured.value = true;
        DebugMessage();
    }

    private void DebugMessage(){
        Debug.Log(persistantMessege);
    }

    public void Test(){
        persistantMessege = "Persistant messege registered. Initial scene index: " + initialSceneIndex;
    }

    private void OnDestroy(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
