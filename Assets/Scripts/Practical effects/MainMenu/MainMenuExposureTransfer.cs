using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuExposureTransfer : MonoBehaviour
{
    [SerializeField] FloatEvent ExposureTransfer;
    [SerializeField] Slider slider;

    private float exposure;

    public void UpdateExposure()
    {
        exposure = -slider.value;
    }

    public void SendExposure()
    {
        ExposureTransfer.Invoke(exposure);
    }
}

