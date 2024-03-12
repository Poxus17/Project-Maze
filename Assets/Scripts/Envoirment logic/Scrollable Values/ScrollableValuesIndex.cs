using System;
using UnityEngine;

public class ScrollableValuesIndex : MonoBehaviour
{
    [SerializeField] bool looping = false;
    [SerializeField, Tooltip("Remember! Index starts at 0")] int maxIndex = 0;
    protected int scrollIndex = 0;
    public int ScrollIndex => scrollIndex;
    

    public event Action ApplyScroll;
    
    public virtual void ScrollForward(){
        if(scrollIndex < maxIndex)
            scrollIndex++;
        else if(looping)
            scrollIndex = 0;
        else
        {
            Debug.Log("Max index reached");
            return;
        }
            
        ApplyScroll();
    }

    public virtual void ScrollBackward(){
        if(scrollIndex > 0)
            scrollIndex--;
        else if(looping)
            scrollIndex = maxIndex;
        else
        {
            Debug.Log("Min index reached");
            return;
        }

        ApplyScroll();
    }
}
