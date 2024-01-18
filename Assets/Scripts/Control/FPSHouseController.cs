using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSHouseController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;


    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    Vector3 moveDirection = Vector3.zero;
    Vector2 rawMovement;
    Vector2 rawLook;
    float rotationX = 0;
    public bool canMove = true;

    CharacterController characterController;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        //bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (true ? runSpeed : walkSpeed) * rawMovement.y : 0;
        float curSpeedY = canMove ? (true ? runSpeed : walkSpeed) * rawMovement.x : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        #region Handles Rotation
        
        if (canMove)
        {
            rotationX += -rawLook.y * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, rawLook.x * lookSpeed, 0);
        }

        #endregion

        /*
        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        

        #endregion
        */
    }

    public void ReadMove(InputAction.CallbackContext context)
    {
        rawMovement = context.ReadValue<Vector2>();
    }

    public void ReadLook(InputAction.CallbackContext context){
        rawLook = context.ReadValue<Vector2>();
    }
}
