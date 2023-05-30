using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSnapTo : MonoBehaviour
{
    public Transform targetTransform;   // The target transform to rotate towards
    public float rotationSpeed = 5f;     // The speed at which the rotation should occur

    private Quaternion initialRotation;  // The initial rotation of the object
    private Quaternion targetRotation;   // The target rotation of the object

    private bool isRotating = false;     // Flag to track if the object is currently rotating

    public void RotateToObject(Transform target)
    {
        targetTransform = target;

        if (!isRotating && targetTransform != null)
        {
            initialRotation = transform.rotation;
            targetRotation = Quaternion.LookRotation(targetTransform.position - transform.position);
            StartCoroutine(RotateCoroutine());
        }
    }

    private IEnumerator RotateCoroutine()
    {
        isRotating = true;

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            // Calculate the rotation step based on the rotation speed and delta time
            float step = rotationSpeed * Time.deltaTime;

            // Rotate towards the target rotation using Slerp for ease-out effect
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);

            yield return null; // Wait for the next frame
        }

        isRotating = false;
    }
}
