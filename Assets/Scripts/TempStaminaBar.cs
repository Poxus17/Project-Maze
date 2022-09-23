using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TempStaminaBar : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image image;
    public void UpdateImage(float percent)
    {
        if (percent > 0.5)
        {
            image.color = new Color(
                Mathf.Lerp(1, 0, (percent - 0.5f) * 2),
                1,
                0
                );
        }
        else
        {
            image.color = new Color(
                1,
                Mathf.Lerp(0, 1, percent* 2),
                0
                );
        }
    }
}

[System.Serializable]
public class FloatEvent : UnityEvent<float> { }
