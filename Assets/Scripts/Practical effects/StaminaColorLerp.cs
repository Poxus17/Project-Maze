using UnityEngine.UI;
using UnityEngine;
using System.Threading;

[RequireComponent(typeof(Image))]
public class StaminaColorLerp : MonoBehaviour
{
    [SerializeField] FloatVariable staminaPercent;
    [SerializeField] BoolVariable staminaRecoveryMode;
    [SerializeField] Color fullColor;
    [SerializeField] Color emptyColor;
    [SerializeField] float colorAlpha = 0.3f;

    private float lastFrameStaminaPercent = 0;

    private Color recoveryColor1;
    private Color recoveryColor2;

    private Image image; //Image.

    private float timer = 0.0f;

    void Start(){
        recoveryColor1 = Color.red;
        recoveryColor2 = Color.black;

        fullColor.a = colorAlpha;
        emptyColor.a = colorAlpha;
        recoveryColor1.a = colorAlpha;
        recoveryColor2.a = colorAlpha;

        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lastFrameStaminaPercent == staminaPercent.value)
            return;

        if(staminaRecoveryMode.value)
            image.color = Color.Lerp(recoveryColor1, recoveryColor2, Mathf.PingPong(Time.time * 3f, 1));
        else
            image.color = Color.Lerp(emptyColor, fullColor, staminaPercent.value);

        lastFrameStaminaPercent = staminaPercent.value;
    }
}
