using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExposureImageAdjust : MonoBehaviour
{

    [SerializeField] Image low;
    [SerializeField] Image mid;
    [SerializeField] Image high;
    [SerializeField] float relationValue;

    [SerializeField] Slider slider;

    private float baseLow;

    private void Start()
    {
        baseLow = low.color.a;
    }

    public void ChangeSlider()
    {
        var setLow = low.color;

        setLow.a = baseLow + (slider.value * relationValue);

        low.color = setLow;
    }
}
