using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_FadeInImage : MonoBehaviour
{
    public Image image; // The Canvas Image to fade in
    public float fadeInDuration = 1f; // The duration of the fade-in effect

    private void Start()
    {
        // Make sure the Image component is assigned
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        StartFadeIn(fadeInDuration);
    }

    public void StartFadeIn(float time)
    {
        StartCoroutine(FadeInCoroutine(time));
    }

    private IEnumerator FadeInCoroutine(float time)
    {
        // Set the initial alpha to 0
        Color startColor = image.color;
        startColor.a = 0f;
        image.color = startColor;

        // Calculate the fade-in speed based on the time and duration
        float fadeSpeed = 1f / fadeInDuration;

        // Fade in the image over time
        while (image.color.a < 1f)
        {
            // Calculate the new alpha value based on the fade-in speed
            float newAlpha = image.color.a + fadeSpeed * Time.deltaTime;

            // Set the new alpha value for the image color
            Color newColor = image.color;
            newColor.a = Mathf.Clamp01(newAlpha);
            image.color = newColor;

            yield return null; // Wait for the next frame
        }
    }
}
