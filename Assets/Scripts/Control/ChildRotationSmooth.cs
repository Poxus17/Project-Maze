using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChildRotationSmooth : MonoBehaviour
{
    [SerializeField] Vector3 smoothOffset;
    [SerializeField] float smoothSpeed;

    Vector3 basePosition;
    Vector3 offsetPosition;

    private void Awake()
    {
        basePosition = transform.localPosition;
    }


    private void LateUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, offsetPosition, smoothSpeed);
    }

    //I really hate this
    public void Look(InputAction.CallbackContext context)
    {
        var contextValue = context.ReadValue<Vector2>().normalized;

        var modX = (contextValue.x != 0) ? contextValue.x / Mathf.Abs(contextValue.x) : 0;
        var modY = (contextValue.y != 0) ? contextValue.y / Mathf.Abs(contextValue.y) : 0;

        var offsetX = basePosition.x + (smoothOffset.x * modX);
        var offsetY = basePosition.y + (smoothOffset.y * modY);

        var posX = Mathf.Lerp(basePosition.x, offsetX, Mathf.Abs(contextValue.x));
        var posY = Mathf.Lerp(basePosition.y, offsetY, Mathf.Abs(contextValue.y));

        offsetPosition = new Vector3(posX, posY, basePosition.z);
    }
}
