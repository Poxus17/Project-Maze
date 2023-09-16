using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCameraController : MonoBehaviour
{
    
    public float maxXRotation = 70f;
    public float smoothSpeed = 0.5f;
    public FloatVariable playerRotationXDelta;
    public FloatVariable playerRotationYDelta;
    [SerializeField] FloatVariable mouseSensitivity;

    private float _xRotation;
    private float _yRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed);

        playerRotationXDelta.value = targetRotation.eulerAngles.x - transform.eulerAngles.x;
        playerRotationYDelta.value = targetRotation.eulerAngles.y - transform.eulerAngles.y;
    }

    public void Look(InputAction.CallbackContext context)
    {
        var contextValue = context.ReadValue<Vector2>();
        _yRotation += contextValue.x * mouseSensitivity.value;
        _xRotation -= contextValue.y * mouseSensitivity.value;
        _xRotation = Mathf.Clamp(_xRotation, -maxXRotation, maxXRotation);
        targetRotation = Quaternion.Euler(_xRotation, _yRotation, 0.0f);
    }
}

