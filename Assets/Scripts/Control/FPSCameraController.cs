using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCameraController : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    public float maxXRotation = 70f;
    private float _xRotation;
    private float _yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

    }

    public void Look(InputAction.CallbackContext context)
    {
        var contextValue = context.ReadValue<Vector2>();
        _yRotation += contextValue.x * horizontalSpeed;
        _xRotation -= contextValue.y * verticalSpeed;
        _xRotation = Mathf.Clamp(_xRotation, -maxXRotation, maxXRotation);
        transform.eulerAngles = new Vector3(_xRotation, _yRotation, 0.0f);

    }
}

