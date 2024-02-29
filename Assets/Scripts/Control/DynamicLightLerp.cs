using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLightLerp : MonoBehaviour
{
    [SerializeField] Light farLight;
    [SerializeField] Light nearLight;

    // Declare a variable to store the distance at which the lerp should start.
    [SerializeField] float lerpDistance = 5.0f;

    // Declare a variable to store the lerp speed.
    [SerializeField] float lerpSpeed = 0.5f;

    //Maximum lights intensity
    [SerializeField] float farLightMaxIntensity;
    [SerializeField] float nearLightMaxIntensity;

    void Update()
    {
        // Raycast from the current position in the forward direction.
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, lerpDistance))
        {
            // If the raycast hits a collider, start lerping.
            float t = (lerpDistance - hit.distance) / lerpDistance;
            t = Mathf.Clamp01(t);

            // Lerp the intensity of the lights.
            farLight.intensity = Mathf.Lerp(farLightMaxIntensity, 0.0f, t);
            nearLight.intensity = Mathf.Lerp(0, nearLightMaxIntensity, t);
        }
        else
        {
            farLight.intensity = farLightMaxIntensity;
            nearLight.intensity = 0f;
        }
    }
}
