using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCameraHandler : MonoBehaviour
{
    [SerializeField] float cameraMovementSpeed = 2;
    private Camera playerCamera;

    public Vector3 position => transform.position;
    public Quaternion rotation => transform.rotation;
    public bool isActive => gameObject.activeSelf;

    private Transform home; // the transform that the camera should return to
    private Transform lender; // the transform that the camera is currently following

    private Vector3 homePosition;
    private Quaternion homeRotation;

    private Vector3 initialLendPosition;
    private Quaternion initialLendRotation;

    public static PlayerCameraHandler instance;

    private event Action onTransitionEnd;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        playerCamera = GetComponent<Camera>();
        home = transform.parent;
        homePosition = transform.localPosition;
        homeRotation = transform.localRotation;
    }

    public void SetCameraActive(bool active)
    {
        playerCamera.enabled = active;
    }

    public Transform LendCameraTo(Transform newParent)
    {
        lender = newParent;
        transform.SetParent(newParent);

        initialLendPosition = transform.position;
        initialLendRotation = transform.rotation;

        return transform;
    }

    public void TransitionLender(Vector3 targetPos, Quaternion targetRot){
        if(lender == null)
            return;

        StartCoroutine(Transition(lender.position, targetPos, lender.rotation, targetRot));
    }

    private IEnumerator Transition(Vector3 initialPos, Vector3 finalPos, Quaternion initialRot, Quaternion finalRot){
        
        var alpha = 0f;
        var distancePos = Vector3.Distance(initialPos, finalPos);

        while(alpha < 1f){
            alpha += (cameraMovementSpeed * Time.deltaTime) / distancePos;
            alpha = Mathf.Clamp01(alpha);
            lender.position = Vector3.Lerp(initialPos, finalPos, alpha);
            lender.rotation = Quaternion.Lerp(initialRot, finalRot, alpha);
            yield return null;
        }

        if(onTransitionEnd != null)
            onTransitionEnd();
    }

    public void ReturnCamera(Action onEnd = null)
    {
        if(lender == null)
            return;

        if(onEnd != null)
        {
            onTransitionEnd += onEnd;
            onTransitionEnd += () => onTransitionEnd -= onEnd;
        }
        
        StartCoroutine(Transition(lender.position, initialLendPosition, lender.rotation, initialLendRotation));
    }

    public void EndCameraLend()
    {
        transform.SetParent(home);
        transform.localPosition = homePosition;
        transform.localRotation = homeRotation;
        lender = null;
    }
}
