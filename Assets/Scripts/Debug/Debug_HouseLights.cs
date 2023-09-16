using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_HouseLights : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] GameObject weakPost;
    [SerializeField] GameObject strongPost;

    bool lightToggle;
    bool postToggle;

    public void Togglelight()
    {
        lightToggle = !lightToggle;
        light.intensity = lightToggle ? 70 : 30;
        light.range = lightToggle ? 10 : 2;
    }

    public void TogglePost()
    {
        postToggle = !postToggle;
        weakPost.SetActive(!postToggle);
        strongPost.SetActive(postToggle);
    }
}
