using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ExposureSet : MonoBehaviour
{
    [SerializeField] Volume volume;
    
    private ColorAdjustments colorAdjustments;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet(out colorAdjustments);
    }

    public void SetBrightness(float exposure)
    {
        volume.enabled = true;
        colorAdjustments.postExposure.value = exposure;
    }
}
