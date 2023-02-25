using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobber : MonoBehaviour
{
    public float delay;
    public float walkingBobbingSpeed;
    public float runningBobbingSpeed;
    public float bobbingAmount = 0.05f;
    [SerializeField] BoolVariable sprint;
    [SerializeField] BoolVariable inTreehouse;
    [SerializeField] float groundY;
    [SerializeField] float treehouseY;

    float defaultPosY = 0;
    float timer = 0;
    float bobbingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        bobbingSpeed = walkingBobbingSpeed;
        defaultPosY = inTreehouse.value ? treehouseY : groundY;
    }

    // Update is called once per frame
    void Update()
    {
        if (FPSMovementController.isWalking)
        {
            //Player is moving
            timer += (Time.deltaTime * bobbingSpeed) - delay;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            //Idle
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * bobbingSpeed), transform.localPosition.z);
        }
    }

    public void changeBobbingSpeed()
    {
        Debug.Log("change bobbing speed");
        bobbingSpeed = sprint.value ? runningBobbingSpeed : walkingBobbingSpeed;
    }

    public void ChangeDefaultY()
    {
        defaultPosY = inTreehouse.value ? treehouseY : groundY;
    }
}
