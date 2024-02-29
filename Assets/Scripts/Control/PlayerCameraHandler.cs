using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCameraHandler : MonoBehaviour
{
    private Camera playerCamera;

    public Vector3 position => transform.position;
    public Quaternion rotation => transform.rotation;
    public bool isActive => gameObject.activeSelf;

    private Transform home; // the transform that the camera should return to
    private Transform lender; // the transform that the camera is currently following

    private Vector3 homePosition;
    private Quaternion homeRotation;

    public static PlayerCameraHandler instance;
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
        return transform;
    }

    public void ReturnCamera()
    {
        transform.SetParent(home);
        transform.localPosition = homePosition;
        transform.localRotation = homeRotation;
        lender = null;
    }
}
