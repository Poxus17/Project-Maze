using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_EaseRorateTo : MonoBehaviour
{
    public Vector3 targetEulerAngles; // The target Euler angles to rotate towards
    public float rotationSpeed = 5f; // The speed at which the rotation should occur

    private Quaternion initialRotation; // The initial rotation of the object
    private Quaternion targetRotation; // The target rotation of the object

    private bool isRotating = false; // Flag to track if the object is currently rotating

    private void Start()
    {
        
    }

    public void RotateToObject()
    {
        initialRotation = transform.localRotation;
        if (!isRotating)
        {
            targetRotation = Quaternion.Euler(targetEulerAngles);
            StartCoroutine(RotateCoroutine());
        }
    }

    private IEnumerator RotateCoroutine()
    {
        isRotating = true;

        while (Quaternion.Angle(transform.localRotation, targetRotation) > 0.01f)
        {
            // Calculate the rotation step based on the rotation speed and delta time
            float step = rotationSpeed * Time.deltaTime;

            // Rotate towards the target rotation using Slerp for ease-out effect
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, step);

            yield return null; // Wait for the next frame
        }

        isRotating = false;
    }
}

