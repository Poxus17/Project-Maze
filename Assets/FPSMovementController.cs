using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSMovementController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    public static bool isWalking;

    Rigidbody rb;
    Vector2 rawMovement;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontal = rawMovement.y * speed * transform.forward;
        var vertical = rawMovement.x * speed * transform.right;

        movement = horizontal + vertical;

        rb.velocity = new Vector3(movement.x, 0, movement.z);
        isWalking = movement.magnitude > 0;
    }

    public void ReadMove(InputAction.CallbackContext context)
    {
        rawMovement = context.ReadValue<Vector2>();
    }
}
