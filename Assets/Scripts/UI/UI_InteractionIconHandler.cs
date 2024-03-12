using UnityEngine;
using UnityEngine.UI;

public class UI_InteractionIconHandler : MonoBehaviour
{
    [SerializeField] StringVariable detectionText;
    [SerializeField] TMPro.TMP_Text textComponent;
    [SerializeField] GameObject icon;
    [SerializeField] Image textBackground;
    [SerializeField] float xFromMouse;
    private RectTransform rectTransform;
    private Vector3 defaultPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultPosition = rectTransform.position;
        SetDetectionText();
    }

    // Update is called once per frame
    void Update()
    {
        HandleDetectionText();

        HandleDetectionPosition();
    }

    private void HandleDetectionText(){
        if (detectionText.value == textComponent.text)
            return;

        if(detectionText.value == "NaN")
        {
            SetInteractionEnabled(false);
            return;
        }

        SetDetectionText();
    }

    private void HandleDetectionPosition(){
        if(detectionText.value != "" && InputSystemHandler.instance.uiMode)
        {
            var screenInteractionPosition = UnityEngine.InputSystem.Mouse.current.position.ReadValue() + (Vector2.right * xFromMouse);
            rectTransform.position = screenInteractionPosition;
        }
        else if(rectTransform.position != defaultPosition)
            rectTransform.position = defaultPosition;
    }

    void SetDetectionText()
    {
        textComponent.text = detectionText.value;

        var enable = (detectionText.value != "");

       SetInteractionEnabled(enable);
    }

    void SetInteractionEnabled(bool enabled)
    {
        textComponent.enabled = enabled;
        textBackground.enabled = enabled;
        icon.SetActive(enabled);
        if (enabled)
            MatchTextBackgroundSize();
    }

    void MatchTextBackgroundSize()
    {
        textComponent.ForceMeshUpdate();

        // Get the rendered size of the text
        Vector2 renderedSize = textComponent.GetRenderedValues(false);

        // Optional: Add some padding if you want
        float padding = 10; // Adjust padding size as needed
        float textWidth = renderedSize.x + (padding * 2);
        float textHeight = renderedSize.y + padding;

        // Resize image's RectTransform to match the rendered text size (with padding)
        RectTransform imageRectTransform = textBackground.rectTransform;
        imageRectTransform.sizeDelta = new Vector2(textWidth, textHeight);
    }
    
}
