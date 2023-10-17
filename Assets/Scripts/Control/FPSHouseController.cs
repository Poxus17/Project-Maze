using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSHouseController : MonoBehaviour
{
    public GameObject directionObject;
    public float speed = 5.0f;
    public float gravity = -9.81f;
    public float maxSlope;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private Vector2 currentMovementInput;
    private bool isGrounded;
    private Vector3 moveDirection;

    private CapsuleCollider capsuleCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb.constraints = RigidbodyConstraints.FreezeRotation; // Prevent the Rigidbody from rotating.
    }

    private void Update()
    {
        DetermineMoveDirection();
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        if (isGrounded)
        {
            MovePlayer();
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();

        FPSMovementController.isWalking = currentMovementInput != Vector2.zero;
    }

    void DetermineMoveDirection()
    {
        Vector3 forwardMovement = directionObject.transform.forward * currentMovementInput.y;
        Vector3 rightMovement = directionObject.transform.right * currentMovementInput.x;
        moveDirection = (forwardMovement + rightMovement).normalized;
    }

    void MovePlayer()
    {
        Vector3 movement = moveDirection * speed * Time.fixedDeltaTime;
        Vector3 newPosition = transform.position + movement;
        rb.MovePosition(newPosition);
    }

    void ApplyGravity()
    {
        // Ground check using a raycast for better ground detection
        float extraHeightText = 0.1f;
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, (capsuleCollider.height * 0.5f) + extraHeightText, groundLayer);

        // Checking the angle of the surface. If it's steeper than maxSlope, then consider the player as not grounded.
        if (isGrounded && Vector3.Angle(hit.normal, Vector3.up) > maxSlope)
        {
            isGrounded = false;
        }

        if (!isGrounded)
        {
            rb.AddForce(new Vector3(0, gravity, 0), ForceMode.Acceleration);
        }
    }
}
