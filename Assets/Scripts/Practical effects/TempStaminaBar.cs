using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TempStaminaBar : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image image;
    [SerializeField] FloatVariable staminaPercent;

    private void Update()
    {
        UpdateImage();
    }

    public void UpdateImage()
    {
        if (staminaPercent.value > 0.5)
        {
            image.color = new Color(
                Mathf.Lerp(1, 0, (staminaPercent.value - 0.5f) * 2),
                1,
                0
                );
        }
        else
        {
            image.color = new Color(
                1,
                Mathf.Lerp(0, 1, staminaPercent.value * 2),
                0
                );
        }

        image.fillAmount = staminaPercent.value;
    }
}

[System.Serializable]
public class FloatEvent : UnityEvent<float> { }
