using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class FPSMovementController : MonoBehaviour
{
    [Header("Speed Settings")]
    [SerializeField] float walkingSpeed = 1;
    [SerializeField] float runningSpeed = 2;
    [SerializeField] float sneakSpeed = 0.7f;
    [SerializeField] float speedLerpTimePerUnit = 0.1f; //per unity is per 1 speed
    [SerializeField] float speedDecay;
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

    [Header("SlideSettings")]
    [SerializeField] float slideSpeed;
    [SerializeField] float slideSpeedRequirement;
    [SerializeField] string slideTrigger;
    [SerializeField] Animator animator; //animator.

    [Header("Local Events")]
    [SerializeField] UnityEvent BrodSprint;
    [Space(10)]

    [Header("Asset Variables")]
    [SerializeField] BoolVariable isSprint;
    [SerializeField] BoolVariable isSneaking;
    [SerializeField] BoolVariable controlLock;
    [SerializeField] FloatVariable staminaPercent;
    [SerializeField] GameEvent LeaveUI;

    public static bool isWalking;

    public delegate void ChangeIsWalking(bool val);
    public static event ChangeIsWalking OnChangeIsWalking;

    public delegate void ChangeMovementType(MovementType moveType);
    public static event ChangeMovementType OnChangeMovementType;

    private static bool walkingMemory = false;

    Rigidbody rb;
    Vector2 rawMovement;
    Vector3 movement;

    bool staminaRecoveryMode;
    bool isCrouching; //reffering to the act, not the state, the state is Sneak
    bool isLerpingSpeed;

    float speed;
    float stamina;

    SpeedLerpObject speedLerpObject;

    

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        speed = walkingSpeed;
        stamina = fullStamina;

        speedLerpObject = new SpeedLerpObject();
        Cursor.visible = false;
    }

    private void Update()
    {
        #region Stamina management
        if (isSprint.value)
        {
            stamina -= staminaDepleteRate * Time.deltaTime;

            if(stamina <= 0)
            {
                staminaRecoveryMode = true;
                isSprint.value = false;
                stamina = 0;
                SetSprint(false);
                //WorldEventDispatcher.instance.BroadcastSprint.Invoke(isSprint.Value);
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

        staminaPercent.value = (stamina / fullStamina);
        #endregion

        if (!controlLock.value)
        {
            #region Movement
            var horizontal = rawMovement.y * speed * transform.forward;
            var vertical = rawMovement.x * speed * transform.right;

            movement = horizontal + vertical;

            if (movement.magnitude == 0 && rb.velocity.x > 0 && speedDecay > 0)
            {
                movement = rb.velocity - (new Vector3(speedDecay, 0, 0));
            }

            rb.velocity = new Vector3(movement.x, 0, movement.z);
            isWalking = movement.magnitude > 0;

            //Notify change in IsWalking
            if (isWalking != walkingMemory)
                OnChangeIsWalking(isWalking);

            walkingMemory = isWalking;

            #endregion
        }

    }

    public void ReadMove(InputAction.CallbackContext context)
    {
        rawMovement = context.ReadValue<Vector2>();
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        /*if (controlLock.value)
            return;*/

        if (!isSneaking.value)
        {
            if ((context.action.triggered || context.action.phase == InputActionPhase.Canceled) && !staminaRecoveryMode)
            {
                SetSprint(context.ReadValue<float>() > 0);
            }
        }
    }

    public void Sneak(InputAction.CallbackContext context)
    {
        /*if (controlLock.value)
            return;*/


        if ((context.action.triggered || context.action.phase == InputActionPhase.Canceled))
        {
            SetSneak(context.ReadValue<float>() > 0);
        }
    }

    void SetSpeed()
    {
        speedLerpObject.SetObjectValues(
            speed,
            isSneaking.value ? sneakSpeed :
                (isSprint.value ? runningSpeed : walkingSpeed)
            );

        if (!isLerpingSpeed)
            StartCoroutine(SpeedLerp());
    }

    void SetSprint(bool setTo)
    {
        isSprint.value = setTo;
        SetSpeed();
        BrodSprint.Invoke();
        OnChangeMovementType(setTo ? MovementType.Run : MovementType.Walk);
    }

    void SetSneak(bool setTo)
    {
        isSneaking.value = setTo;
        SetSpeed();
        OnChangeMovementType(setTo ? MovementType.Sneak : MovementType.Walk);
        StartCoroutine(TransitionCrouch(setTo));

        if (isSprint.value && isSneaking.value)
            SetSprint(false);

        /*if (speed >= slideSpeedRequirement)
        {
            animator.SetTrigger(slideTrigger);
            StartCoroutine(SlideAction());
        }
        else
        {
            isSneaking.value = setTo;
            SetSpeed();
            OnChangeMovementType(setTo ? MovementType.Sneak : MovementType.Walk);
            StartCoroutine(TransitionCrouch(setTo));

            if (isSprint.value && isSneaking.value)
                SetSprint(false);
        }*/
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

    public void InvokeLeaveUI()
    {
        LeaveUI.Raise();
    }

    public float GetSpeedLerpTime()
    {
        if (isSneaking.value)
            return Mathf.Abs(speed - sneakSpeed) * speedLerpTimePerUnit;
        else if (isSprint.value)
            return (Mathf.Abs(speed - runningSpeed) * speedLerpTimePerUnit);
        else
            return Mathf.Abs(speed - walkingSpeed) * speedLerpTimePerUnit;
    }


    IEnumerator SpeedLerp()
    {
        isLerpingSpeed = true;
        float alphaDelta = 1 / GetSpeedLerpTime();
        speedLerpObject.ConsumeRestart();

        while (speedLerpObject.alpha < 1.0f)
        {
            if (speedLerpObject.restart)
            {
                speedLerpObject.ConsumeRestart();
                alphaDelta = 1 / GetSpeedLerpTime();
            }
                

            speed = Mathf.Lerp(speedLerpObject.speedA, speedLerpObject.speedB, speedLerpObject.alpha);
            yield return null;


            speedLerpObject.alpha += alphaDelta * Time.deltaTime;
        }

        isLerpingSpeed = false;
    }

    IEnumerator SlideAction()
    {
        controlLock.value = true;

        Vector3 move;
        var time = 0.0f;

        while(time < 1)
        {
            move = slideSpeed * transform.forward;
            rb.velocity = new Vector3(move.x, 0, move.z);
            time += Time.deltaTime;
            yield return null;
        }
        controlLock.value = false;
    }
}

public enum MovementType { Walk, Run, Sneak}

class SpeedLerpObject
{
    public float speedA { get; private set; }
    public float speedB { get; private set; }
    public float alpha;
    public bool restart { get; private set; }

    public SpeedLerpObject()
    {
        speedA = 0f;
        speedB = 0f;
        alpha = 0f;
        restart = false;
    }

    public void SetObjectValues(float speedA, float speedB)
    {
        this.speedA = speedA;
        this.speedB = speedB;
        restart = true;
    }

    public void ConsumeRestart()
    {
        restart = false;
        alpha = 0f;
    }
}