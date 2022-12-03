using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ExposureSet : MonoBehaviour
{
    [SerializeField] float baseExposure;
    [SerializeField] float baseIntensity;
    [SerializeField] Volume volume;
    [SerializeField] Light directionalLight;
    [SerializeField] FloatVariable exposure;
    [SerializeField] FloatVariable lightIntensity;

    private ColorAdjustments colorAdjustments;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet(out colorAdjustments);
        SetBrightness();
    }

    public void SetBrightness()
    {
        volume.enabled = true;
        colorAdjustments.postExposure.value = exposure.value + baseExposure;
        directionalLight.intensity = lightIntensity.value + baseIntensity;
    }
}
