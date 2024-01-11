using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class ExposureSet : MonoBehaviour
{
    [SerializeField] float baseExposure;
    //[SerializeField] float baseIntensity;
    [SerializeField] Volume volume;
    //[SerializeField] Light directionalLight;
    [SerializeField] FloatVariable exposureVal;
    [SerializeField] FloatVariable lightIntensity;
    [SerializeField] FloatAnnouncerVariable liveExposureVar;

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
            SetLiveBrightness();
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

    public void SetLiveBrightness()
    {
        exposure.limitMin.value = liveExposureVar.value;
    }
}
