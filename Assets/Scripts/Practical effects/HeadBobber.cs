using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobber : MonoBehaviour
{
    public float delay;
    public float walkingBobbingSpeed;
    public float runningBobbingSpeed;
    public float bobbingAmountX;
    public float bobbingAmountY;
    public float bobbingSwayRotationAmount;
    public FloatVariable testingSwayRotationAmount;
    [SerializeField] BoolVariable sprint;
    [SerializeField] BoolVariable isSneaking;
    [SerializeField] BoolVariable cameraTransition;
    [SerializeField] float baseY;
    [SerializeField] float sneakY;


    float defaultPosY;
    float defaultPosX;
    float timer = 0;
    float bobbingSpeed;


    // Start is called before the first frame update
    void Start()
    {
        bobbingSpeed = walkingBobbingSpeed;
        defaultPosY = isSneaking.value ? sneakY : baseY;
        defaultPosX = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraTransition.value)
        {
            timer = 0;
            return;
        }
            

        if (FPSMovementController.isWalking)
        {
            //Player is moving
            timer += (Time.deltaTime * bobbingSpeed) - delay;

            transform.localPosition = new Vector3(
                defaultPosX + Mathf.Sin(timer * bobbingSpeed / 2) * bobbingAmountX, 
                defaultPosY + Mathf.Sin(timer* bobbingSpeed) * bobbingAmountY, 
                transform.localPosition.z
                );

            transform.localEulerAngles = new Vector3(0, 0, Mathf.Sin(-timer * bobbingSpeed / 2) * testingSwayRotationAmount.value);
        }
        else
        {
            //Idle
            timer = 0;
            transform.localPosition = new Vector3(
                Mathf.Lerp(transform.localPosition.x,defaultPosX, Time.deltaTime * bobbingSpeed), 
                Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * bobbingSpeed), 
                transform.localPosition.z
                );

            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void changeBobbingSpeed()
    {
        Debug.Log("change bobbing speed");
        bobbingSpeed = sprint.value ? runningBobbingSpeed : walkingBobbingSpeed;
    }

    public void ChangeDefaultY()
    {
        defaultPosY = isSneaking.value ? sneakY : baseY;
    }
}
