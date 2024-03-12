using UnityEngine;

public class LoadAgent : MonoBehaviour
{

    public void NewSave(){
        SaveSystem.DeleteSaveFile();
    }

    public void RecordAbsolteData(){
        SaveManager.instance.SaveAbsoluteData();
    }

    public void StealthLoad(int index){
        PersistantManager.instance.LoadScene(index, true);
    }
}
