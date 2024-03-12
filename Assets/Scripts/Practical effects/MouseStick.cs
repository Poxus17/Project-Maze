using UnityEngine;

public class MouseStick : MonoBehaviour
{
    [SerializeField] float stickDistance;
    private UnityEngine.InputSystem.Mouse mouse;
    private Vector3 originPosition;

    private void Start(){
        mouse = UnityEngine.InputSystem.Mouse.current;
        this.enabled = false;
        originPosition = transform.position;
    }

    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouse.position.ReadValue().x, mouse.position.ReadValue().y, stickDistance));
    }

    public void EnableMouseStick(){
        this.enabled = true;
    }

    public void DisableMouseStick(){
        this.enabled = false;
    }

    public void resetLocation(){
        transform.position = originPosition;
    }
}
