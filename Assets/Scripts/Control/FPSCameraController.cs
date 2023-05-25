using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCameraController : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    public float maxXRotation = 70f;
    public float smoothSpeed = 0.5f;
    public FloatVariable playerRotationXDelta;
    public FloatVariable playerRotationYDelta;

    private float _xRotation;
    private float _yRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        _yRotation += contextValue.x * horizontalSpeed;
        _xRotation -= contextValue.y * verticalSpeed;
        _xRotation = Mathf.Clamp(_xRotation, -maxXRotation, maxXRotation);
        targetRotation = Quaternion.Euler(_xRotation, _yRotation, 0.0f);
    }
}

