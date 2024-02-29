using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FvalToImageFill : MonoBehaviour
{
    [SerializeField] FloatVariable floatVariable;
    [SerializeField] float maxValue;
    [SerializeField] FloatVariable outFillAmount;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        var fillAmount = floatVariable.value / maxValue;

        if (outFillAmount != null)
            outFillAmount.value = fillAmount;

        image.fillAmount = fillAmount;
    }
}
