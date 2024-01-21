using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCameraHandler : MonoBehaviour
{
    private Camera playerCamera;

    public Vector3 position => transform.position;
    public Quaternion rotation => transform.rotation;

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
    }

    public void SetCameraActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
