using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderToValue : MonoBehaviour
{
    [SerializeField] FloatVariable sliderVar;
    [SerializeField] float minValue;
    [SerializeField] float maxValue;

    Slider slider; //Slider.

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        slider.value = Mathf.InverseLerp(minValue, maxValue, sliderVar.value);
    }

    public void ChangeValue()
    {
        var lerpedValue = Mathf.Lerp(minValue, maxValue, slider.value);
        if (sliderVar is FloatAnnouncerVariable)
        {
            FloatAnnouncerVariable castVar = (FloatAnnouncerVariable)sliderVar;
            castVar.AnnounceSet(lerpedValue);
        }
        else    
            sliderVar.value = lerpedValue;
    }
}
