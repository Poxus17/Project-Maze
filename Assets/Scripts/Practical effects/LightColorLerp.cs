using UnityEngine;

public class LightColorLerp : MonoBehaviour
{
    [SerializeField] Color color1;
    [SerializeField] Color color2;
    [SerializeField] FloatVariable alphaValue;
    [SerializeField] float maxValue;
    [SerializeField] float minValue;

    [Space(5)]
    [Header("Custom update")]
    [SerializeField] float customUpdateRate = 1f;

    private Light light;


    private void Awake(){
        light = GetComponent<Light>();
        CustomUpdate();
    }

    private void CustomUpdate()
    {
        float lerpValue = Mathf.InverseLerp(minValue, maxValue, alphaValue.value);
        light.color = Color.Lerp(color1, color2, lerpValue);

        if(gameObject.activeInHierarchy)
            GlobalTimerManager.instance.RegisterForTimer(CustomUpdate, customUpdateRate);
    }
 }
