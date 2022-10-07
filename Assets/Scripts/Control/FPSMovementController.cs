using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSMovementController : MonoBehaviour
{
    [SerializeField] float walkingSpeed = 1;
    [SerializeField] float runningSpeed = 2;
    [SerializeField] float fullStamina;
    [SerializeField] float staminaDepleteRate;
    [SerializeField] float staminaRestoreRate;
    public FloatEvent StaminaBroadcast;

    public static bool isWalking;
    public delegate void ChangeIsWalking(bool val);
    public static event ChangeIsWalking OnChangeIsWalking;
    private static bool walkingMemory = false;

    Rigidbody rb;
    Vector2 rawMovement;
    Vector3 movement;

    bool isRunning;
    bool staminaRecoveryMode;

    float speed;
    float stamina;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        speed = walkingSpeed;
        stamina = fullStamina;
    }

    private void Update()
    {
        #region Stamina management
        if (isRunning)
        {
            stamina -= staminaDepleteRate * Time.deltaTime;

            if(stamina <= 0)
            {
                staminaRecoveryMode = true;
                isRunning = false;
                stamina = 0;
                SetSpeed();
                WorldEventDispatcher.instance.BroadcastSprint.Invoke(isRunning);
            }
        }
        else if(stamina < fullStamina)
        {
            stamina += staminaRestoreRate * Time.deltaTime;

            if(stamina >= fullStamina)
            {
                stamina = fullStamina;
                staminaRecoveryMode = false;
            }
        }

        StaminaBroadcast.Invoke(stamina / fullStamina);
        #endregion

        #region Movement
        var horizontal = rawMovement.y * speed * transform.forward;
        var vertical = rawMovement.x * speed * transform.right;

        movement = horizontal + vertical;

        rb.velocity = new Vector3(movement.x, 0, movement.z);
        isWalking = movement.magnitude > 0;

        //Notify change in IsWalking;
        if (isWalking != walkingMemory)
            OnChangeIsWalking(isWalking);

        walkingMemory = isWalking;

        #endregion
    }

    public void ReadMove(InputAction.CallbackContext context)
    {
        rawMovement = context.ReadValue<Vector2>();
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if ((context.action.triggered || context.action.phase == InputActionPhase.Canceled) && !staminaRecoveryMode)
        {
            isRunning = context.ReadValue<float>() > 0;
            SetSpeed();
            WorldEventDispatcher.instance.BroadcastSprint.Invoke(isRunning);
        }
    }

    void SetSpeed()
    {
        speed = isRunning ? runningSpeed : walkingSpeed;
    }
}
