using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class ExposureSet : MonoBehaviour
{
    [SerializeField] float baseExposure;
    [SerializeField] float baseIntensity;
    [SerializeField] Volume volume;
    [SerializeField] Light directionalLight;
    [SerializeField] FloatVariable exposureVal;
    [SerializeField] FloatVariable lightIntensity;
    [SerializeField] FloatAnnouncerVariable debugExposureVar;

    private ColorAdjustments colorAdjustments;
    private Exposure exposure;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (volume.profile.TryGet(out exposure))
            SetDebugBrightness();
        else
            Debug.Log("No exposure");
    }

    public void SetBrightness()
    {
        volume.enabled = true;
        exposure.fixedExposure.value = baseExposure - exposureVal.value;

        /*colorAdjustments.postExposure.value = exposureVal.value + baseExposure;
        directionalLight.intensity = lightIntensity.value + baseIntensity;*/
    }

    public void SetDebugBrightness()
    {
        Debug.Log("Setting exposure");
        exposure.compensation.value = baseExposure - debugExposureVar.value;
    }
}
