using UnityEngine;

[RequireComponent(typeof(Light))]
public class FlashlightHandler : MonoBehaviour
{
    private bool isOn = false;
    private Light flashlight;

    private void Awake()
    {
        flashlight = GetComponent<Light>();
    }

    public void ToggleFlashlight(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(!context.performed)
            return;
        isOn = !isOn;
        flashlight.enabled = isOn;
    }

    
}
