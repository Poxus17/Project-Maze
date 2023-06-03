using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderToValue : MonoBehaviour
{
    [SerializeField] FloatVariable mouseSensitivity;
    [SerializeField] float minValue;
    [SerializeField] float maxValue;

    Slider slider; //Slider.

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeValue()
    {
        mouseSensitivity.value = Mathf.Lerp(minValue, maxValue, slider.value);
    }
}
