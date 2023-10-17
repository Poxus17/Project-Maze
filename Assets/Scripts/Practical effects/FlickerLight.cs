using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public string morseCode = "01";  // Your Morse Code input, e.g., "00120001301".
    public float dotDuration = 0.5f;  // Duration of a dot.

    public MeshRenderer targetRenderer;  // MeshRenderer whose material will be changed.
    public Material lightOnMaterial;     // Material to use when the light is on.
    public Material lightOffMaterial;    // Material to use when the light is off.

    private Light lightSource;
    private bool isLightOn = false;
    private int currentIndex = 0;  // To keep track of the Morse Code string index.

    private float timer = 0.0f;

    private void Start()
    {
        lightSource = GetComponent<Light>();
        BeginFlicker();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (currentIndex >= morseCode.Length)
            currentIndex = 0;

        char currentCode = morseCode[currentIndex];

        if (isLightOn && ((currentCode == '0' && timer >= dotDuration) || (currentCode == '1' && timer >= dotDuration * 3)))
        {
            TurnOffLight();
        }
        else if (!isLightOn && ((currentCode == '0' && timer >= dotDuration) ||
                                (currentCode == '1' && timer >= dotDuration * 3) ||
                                (currentCode == '2' && timer >= dotDuration * 3) ||  // short pause
                                (currentCode == '3' && timer >= dotDuration * 7)))   // long pause
        {
            BeginFlicker();
        }
    }

    private void TurnOffLight()
    {
        isLightOn = false;
        lightSource.intensity = 0;
        targetRenderer.material = lightOffMaterial;
        timer = 0f;
    }

    private void BeginFlicker()
    {
        currentIndex++;

        if (currentIndex >= morseCode.Length)
        {
            currentIndex = 0;  // Loop back to the start.
        }

        char currentCode = morseCode[currentIndex];

        if (currentCode == '0' || currentCode == '1')
        {
            isLightOn = true;
            lightSource.intensity = 1;
            targetRenderer.material = lightOnMaterial;
            timer = 0f;
        }
        else
        {
            // If it's a pause, we just reset the timer and wait.
            timer = 0f;
        }
    }
}
