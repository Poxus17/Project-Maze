using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InteractionIconHandler : MonoBehaviour
{
    [SerializeField] StringVariable detectionText;
    [SerializeField] TMPro.TMP_Text textComponent;


    private void Start()
    {
        SetDetectionText();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectionText.value != textComponent.text)
            SetDetectionText();
    }

    void SetDetectionText()
    {
        textComponent.text = detectionText.value;
        textComponent.enabled = (detectionText.value != "");
    }
}
