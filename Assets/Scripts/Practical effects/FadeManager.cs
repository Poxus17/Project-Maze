using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField] float fadeSpeed;
    [SerializeField] Image fadeImage;

    private event Action endFadeEvent;

    public static FadeManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void DelayedFadeIn(float delay){
        GlobalTimerManager.instance.RegisterForTimer(() => {Fade(false);}, delay);
    }

    public void Fade(bool forward){
        StartCoroutine(FadeCoroutine(forward));
    }
    public void Fade(bool forward, Action fadeEnd)
    {
        endFadeEvent += fadeEnd;
        StartCoroutine(FadeCoroutine(forward));
    }

    IEnumerator FadeCoroutine(bool forward)
    {
        int mod = forward ? 1 : -1;
        float alpha = fadeImage.color.a;

        while(forward ? (alpha <1): (alpha > 0))
        {
            alpha +=  mod * (Time.deltaTime / fadeSpeed);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        if(endFadeEvent != null){
            endFadeEvent();
            ClearEndFadeEvent();
        }
    }

    private void ClearEndFadeEvent(){
        foreach(Action action in endFadeEvent.GetInvocationList())
                endFadeEvent -= action;
    }

    private void OnDestroy(){
        if(endFadeEvent != null)
            ClearEndFadeEvent();
    }

}
