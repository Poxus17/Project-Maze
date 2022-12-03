using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuExposureTransfer : MonoBehaviour
{
    [Header("Asset variables")]
    [SerializeField] FloatVariable exposure;
    [SerializeField] FloatVariable lightIntensity;
    [Space(10)]

    [Header("Settings")]
    [SerializeField] Slider slider;
    [SerializeField] float exposureMultiplier;
    [SerializeField] float lightIntensityMultiplier;

    public void UpdateAssetValues()
    {
        exposure.value = -slider.value * exposureMultiplier;
        lightIntensity.value = -slider.value * lightIntensityMultiplier;
        Debug.Log(exposure.value + " -- " + lightIntensity.value);
    }
}

