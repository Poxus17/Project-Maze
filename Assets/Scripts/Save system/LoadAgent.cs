using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadAgent : MonoBehaviour
{

    public void NewSave(){
        SaveSystem.DeleteSaveFile();
    }

    public void RecordAbsolteData(){
        SaveManager.instance.SaveAbsoluteData();
    }
}
