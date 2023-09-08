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
        StartCoroutine(CutsceneTimer(time));
    }

    private IEnumerator CutsceneTimer(float time)
    {
        yield return new WaitForSeconds(time);
        InputSystemHandler.instance.SetInputActive(true);
    }
}
