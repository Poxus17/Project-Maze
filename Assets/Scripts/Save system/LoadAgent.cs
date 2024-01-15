using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAgent : MonoBehaviour
{
    public void NewSave(){
        SaveSystem.DeleteSaveFile();
    }
}
