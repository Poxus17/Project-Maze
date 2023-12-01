using UnityEngine;

public class SaveEventComponent : MonoBehaviour
{
    [SerializeField] int saveIndex;

    public void SaveEvent()
    {
        Debug.Log("Saved event");
        SaveManager.instance.registerSavedEvent(saveIndex); 
    }
}
