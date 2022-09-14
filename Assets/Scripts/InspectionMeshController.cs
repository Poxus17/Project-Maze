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

    void Start()
    {
        
    }

    public void MoveInspection(InputAction.CallbackContext context)
    {
        if (rightClick)
        {
            var value = context.ReadValue<Vector2>();
            if (currentMousePos == Vector2.zero)
                currentMousePos = value;
            var delta = currentMousePos - value;
            delta *= deltaRotationRatio;
            inspectionMesh.transform.eulerAngles += new Vector3(0,delta.x, delta.y);

            currentMousePos = value;
        }
        else
        {
            currentMousePos = Vector2.zero;
        }
    }

    public void AllowInspectionRotation(InputAction.CallbackContext context)
    {
        rightClick = !rightClick;
    }
}
