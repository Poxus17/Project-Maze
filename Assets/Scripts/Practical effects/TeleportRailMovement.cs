using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRailMovement : MonoBehaviour
{
    //Public variables
    [SerializeField, Tooltip("The direction of the movement, expressed as a forward vector. Relative to world axis")] 
    Vector3 direction;
    [SerializeField, Tooltip("Movement speed during walking segments")] 
    float speed;
    [SerializeField, Tooltip("The minimal length of time of a segment (either walking or hidden)")] 
    float minSegmentTime;
    [SerializeField, Tooltip("The maximal length of time of a segment (either walking or hidden)")] 
    float maxSegmentTime;
    [SerializeField, Tooltip("The max horizontal offset from center the model can be stationed")]
    float horizontalRadius;
    [SerializeField, Tooltip("The minimal forward skip during a teleport")]
    float minForwardSkip;
    [SerializeField, Tooltip("The maximum forward skip during a teleport")]
    float maxForwardSkip;


    //Local variables
    [Tooltip("When true, the next zip action will be to the right, when false it will be to the left")]
    bool zipRight;
    [Tooltip("When true, the next segment will be hidden, when false it will be walking")]
    bool isWalking;
    [Tooltip("The counting component of the timer")]
    float timer;
    [Tooltip("The current amount of time the timer is counting to before a zip occures")]
    float currentTimeCap;
    [Tooltip("The current offset from center (to either direction)")]
    float currentOffset;
    [Tooltip("The base Y for walking segment")]
    float baseY;

    // Start is called before the first frame update
    void Start()
    {
        zipRight = (Random.value >= 0.5f); //Flip a coin for the first direction
        isWalking = true;
        currentOffset = 0;
        baseY = transform.position.y;

        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        //Rail movement for walking segment
        if(isWalking)
            transform.position += direction * speed * Time.deltaTime;

        //Timer for teleport
        timer += Time.deltaTime;
        if (timer < currentTimeCap) return;

        Teleport();
    }

    void ResetTimer()
    {
        timer = 0;
        currentTimeCap = Random.Range(minSegmentTime, maxSegmentTime);
    }

    void Teleport()
    {
        isWalking = !isWalking;

        Vector3 fixedPosition;
        if (isWalking)
        {
            var zip = WalkingSegmentZip();
            fixedPosition = new Vector3 (zip.x, baseY, zip.z);
        }
        else
        {
            var position = transform.position;
            fixedPosition = new Vector3(position.x, -300f, position.z);
        }
        transform.position = fixedPosition;

        ResetTimer();
    }

    Vector3 WalkingSegmentZip()
    {
        float directionMod = zipRight ? 1 : -1;
        float zipOffset = Random.Range(0, horizontalRadius / 2); //Randomize the length of the zip
        float zipLength = zipOffset + currentOffset; // Added to the current offset from center to get it to the other side of the hall

        currentOffset = zipOffset;
        float zipForward = Random.Range(minForwardSkip, maxForwardSkip);

        Vector3 horizontalZipValue = (directionMod * zipLength) * transform.right;
        Vector3 forwardZipValue = zipForward * transform.forward;

        Vector3 zipTarget = transform.position + horizontalZipValue + forwardZipValue;

        zipRight = !zipRight;

        return zipTarget;
    }
}
