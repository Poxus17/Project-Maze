using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cutscene_Controller : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] AudioClip[] stepClips;
    Vector3 rawMovement;
    Rigidbody rb;

    bool isWalking = false;
    bool wasWalking = false;
    bool playingStep = false;
    bool activeStep = false;

    float timer;
    float bobbingSpeed = 15;
    float bobbingAmount = 0.2f;
    float defaultPosY;
    float stepTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        wasWalking = false;
        rb = GetComponent<Rigidbody>();
        defaultPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = rawMovement.y * speed * transform.forward;
        var vertical = rawMovement.x * speed * transform.forward;

        var movement = horizontal + vertical;

        rb.velocity = new Vector3(movement.x, 0, movement.z);
        isWalking = movement.magnitude > 0;

        if(isWalking != wasWalking)
        {
            SetActiveStep(isWalking);
        }
        wasWalking = isWalking;

        if (isWalking)
        {
            //Player is moving
            timer += Time.deltaTime * bobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            //Idle
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * bobbingSpeed), transform.localPosition.z);
        }
    }

    public void ReadMove(InputAction.CallbackContext context)
    {
        rawMovement = context.ReadValue<Vector2>();

        rawMovement.x = 0;
        rawMovement.y = Mathf.Clamp(rawMovement.y, 0, 2);
    }
    void SetActiveStep(bool val)
    {
        var wasActive = activeStep;
        activeStep = val;

        if (activeStep && !wasActive && !playingStep)
        {
            StartCoroutine(StepsLoop());
        }
    }
    IEnumerator StepsLoop()
    {
        playingStep = true;
        var selectClip = stepClips[Random.Range(0, stepClips.Length)];
        MusicMan.instance.PlaySE(selectClip, 0.5f);

        yield return new WaitForSeconds(stepTime);

        if (activeStep)
            StartCoroutine(StepsLoop());
        else
            playingStep = false;
    }
}
