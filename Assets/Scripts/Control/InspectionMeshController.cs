using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InspectionMeshController : MonoBehaviour
{
    [SerializeField] GameObject inspectionMesh;
    [SerializeField] float deltaRotationRatio;

    bool rightClick = false;
    Vector2 currentMousePos;

    public void MoveInspection(InputAction.CallbackContext context)
    {
        if (rightClick)
        {
            var value = context.ReadValue<Vector2>();
            if (currentMousePos == Vector2.zero)
                currentMousePos = value;
            var delta = currentMousePos - value;
            delta *= deltaRotationRatio;
            inspectionMesh.transform.Rotate(-delta.y, delta.x, 0, Space.World);

            currentMousePos = value;
        }
        else
        {
            currentMousePos = Vector2.zero;
        }
    }

    public void AllowInspectionRotation(InputAction.CallbackContext context)
    {
        if (context.started)
            rightClick = true;
        else if(context.canceled)
            rightClick = false;
    }
}
