using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_LerpLightIntensity : MonoBehaviour
{
    [HideInInspector] public bool allowLerp;

    [SerializeField] Light light;
    [SerializeField] float lerpTime;
    [SerializeField] float intensityVal;
    [SerializeField] bool onStart = true;

    float lerpAlpha;
    float timer;

    private void Start()
    {
        timer = 0;

        if (onStart)
            allowLerp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (allowLerp)
        {
            light.intensity = Mathf.Lerp(0, intensityVal, (timer / lerpTime));
            timer += Time.deltaTime;
        }
    }
}
