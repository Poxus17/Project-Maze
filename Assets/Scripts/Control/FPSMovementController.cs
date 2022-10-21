using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSMovementController : MonoBehaviour
{
    [Header("Speed Settings")]
    [SerializeField] float walkingSpeed = 1;
    [SerializeField] float runningSpeed = 2;
    [SerializeField] float sneakSpeed = 0.7f;
    [Space(10)]

    [Header("Stamina Settings")]
    [SerializeField] float fullStamina;
    [SerializeField] float staminaDepleteRate;
    [SerializeField] float staminaRestoreRate;
    [Space(10)]

    [Header("Crouch Settings")]
    [SerializeField] float localStandingY;
    [SerializeField] float localCrouchingY;
    [SerializeField] float crouchTranisitonSpeed;
    [SerializeField] GameObject camera;
    [Space(10)]

    public FloatEvent StaminaBroadcast;

    public static bool isWalking;

    public delegate void ChangeIsWalking(bool val);
    public static event ChangeIsWalking OnChangeIsWalking;

    public delegate void ChangeMovementType(MovementType moveType);
    public static event ChangeMovementType OnChangeMovementType;

    private static bool walkingMemory = false;

    Rigidbody rb;
    Vector2 rawMovement;
    Vector3 movement;

    bool isRunning;
    bool isSneaking;
    bool staminaRecoveryMode;
    bool isCrouching; //reffering to the act, not the state, the state is Sneak

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

        //Notify change in IsWalking
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
        if (!isSneaking)
        {
            if ((context.action.triggered || context.action.phase == InputActionPhase.Canceled) && !staminaRecoveryMode)
            {
                SetSprint(context.ReadValue<float>() > 0);
            }
        }
    }

    public void Sneak(InputAction.CallbackContext context)
    {
        if ((context.action.triggered || context.action.phase == InputActionPhase.Canceled) && !isCrouching)
        {
            SetSneak(context.ReadValue<float>() > 0);
        }
    }

    void SetSpeed()
    {
        speed = isSneaking ? sneakSpeed :
            (isRunning ? runningSpeed : walkingSpeed);
    }

    void SetSprint(bool setTo)
    {
        isRunning = setTo;
        SetSpeed();
        WorldEventDispatcher.instance.BroadcastSprint.Invoke(isRunning);
        OnChangeMovementType(setTo ? MovementType.Run : MovementType.Walk);
    }

    void SetSneak(bool setTo)
    {
        isSneaking = setTo;
        SetSpeed();
        OnChangeMovementType(setTo ? MovementType.Sneak : MovementType.Walk);
        StartCoroutine(TransitionCrouch(setTo));

        if (isRunning && isSneaking)
            SetSprint(false);
    }

    IEnumerator TransitionCrouch(bool toCrouch)
    {
        isCrouching = true;

        var pos = camera.transform.localPosition;
        var startY = toCrouch ? localStandingY : localCrouchingY;
        var endY = toCrouch ? localCrouchingY : localStandingY;
        camera.transform.localPosition = new Vector3(pos.x, startY, pos.z);

        var alpha = 0.0f;

        while(alpha < 1.0f)
        {
            alpha += Time.deltaTime * crouchTranisitonSpeed;
            pos.y = Mathf.Lerp(startY, endY, alpha);
            camera.transform.localPosition = pos;
            yield return null;
        }

        camera.transform.localPosition = new Vector3(pos.x, endY, pos.z);

        isCrouching = false;
    }
}

public enum MovementType { Walk, Run, Sneak}