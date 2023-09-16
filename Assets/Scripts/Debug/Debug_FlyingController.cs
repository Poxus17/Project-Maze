using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Debug_FlyingController : MonoBehaviour
{

    public float normalspeed = 1;
    public float slowSpeed = 0.1f;
    public GameObject camera;
    float speed;
    bool slow = false;
    float raw3d;
    Vector3 rawMovement;

    // Start is called before the first frame update
    void Start()
    {
        speed = normalspeed;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = rawMovement.y * speed * camera.transform.forward;
        var vertical = rawMovement.x * speed * camera.transform.right;
        var axis = new Vector3(0, raw3d * speed, 0);

        transform.position += horizontal + vertical + axis;
    }

    public void ReadMove(InputAction.CallbackContext context)
    {
        rawMovement = context.ReadValue<Vector2>();
    }

    public void Read3D(InputAction.CallbackContext context)
    {
        raw3d = context.ReadValue<float>();
    }

    public void ToggleSlow()
    {
        slow = !slow;
        speed = slow ? slowSpeed : normalspeed;
    }
}
