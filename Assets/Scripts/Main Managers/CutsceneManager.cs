using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{

    //CutsceneComponent[] cutscenes;

    private void Start()
    {
        //cutscenes = FindObjectsOfType<CutsceneComponent>();
    }


    public void PlayCutscene(float time)
    {
        InputSystemHandler.instance.SetInputActive(false);
        GlobalTimerManager.instance.RegisterForTimer(() => { InputSystemHandler.instance.SetInputActive(true); }, time);
    }
}
