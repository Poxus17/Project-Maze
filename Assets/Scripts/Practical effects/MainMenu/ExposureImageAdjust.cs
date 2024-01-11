using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExposureImageAdjust : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] FloatAnnouncerVariable exposureVar;

    private float baseLow;

    private void Start()
    {

    }

    public void ChangeSlider()
    {
        exposureVar.AnnounceSet(slider.value);
    }
}
