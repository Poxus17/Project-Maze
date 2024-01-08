using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif // UNITY_EDITOR

public class ZippedMovement : MonoBehaviour
{
    //Public variables
    [SerializeField, Tooltip("The minimal amount of time elapsed between zips")] 
    float minTimeElapse;
    [SerializeField, Tooltip("The maximal amount of time elapsed between zips")] 
    float maxTimeElapse;
    [SerializeField, Tooltip("The length of time of a zip")] 
    float zipDurationTime;
    [Tooltip("the max distance forward object will skip in a zip. The min is 0")] 
    public float maxForwardZip;
    [Tooltip("The width of the area to zip in")] 
    public float zipAreaWidth;

    //Local variables
    [Tooltip("When true, the next zip action will be to the right, when false it will be to the left")] 
    bool zipRight; 
    [Tooltip("The counting component of the timer")]
    float timer;
    [Tooltip("The current amount of time the timer is counting to before a zip occures")] 
    float currentTimeCap;
    [Tooltip("The current offset from center (to either direction)")]
    float currentOffset;

    // Start is called before the first frame update
    void Start()
    {
        zipRight = (Random.value >= 0.5f); //Flip a coin for the first direction
        currentOffset = 0;
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < currentTimeCap) return;

        Zip();
        ResetTimer();
    }

    void ResetTimer()
    {
        timer = 0;
        currentTimeCap = Random.Range(minTimeElapse, maxTimeElapse);
    }

    void Zip()
    {
        float directionMod = zipRight ? 1 : -1;
        float zipOffset = Random.Range(0, zipAreaWidth / 2); //Randomize the length of the zip
        float zipLength = zipOffset + currentOffset; // Added to the current offset from center to get it to the other side of the hall

        currentOffset = zipOffset;
        float zipForward = Random.Range(0, maxForwardZip);

        Vector3 horizontalZipValue = (directionMod * zipLength) * transform.right;
        Vector3 forwardZipValue = zipForward * transform.forward;

        Vector3 zipTarget = transform.position + horizontalZipValue + forwardZipValue;

        zipRight = !zipRight;

        StartCoroutine(ZipTransition(zipTarget));
    }

    IEnumerator ZipTransition(Vector3 target)
    {
        float zipTimer = 0;
        Vector3 pos0 = transform.position;

        while(zipTimer < zipDurationTime)
        {
            transform.position = Vector3.Lerp(pos0, target, (zipTimer / zipDurationTime));

            yield return null;

            zipTimer += Time.deltaTime;
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ZippedMovement))]
public class ZippedMovementVisualizerEditor : Editor
{
    public void OnSceneGUI()
    {
        var zip = target as ZippedMovement;
        var zipWidthSide = zip.transform.right * (zip.zipAreaWidth / 2);

        var targetPos1 = zip.transform.position + zipWidthSide;
        var targetPos2 = zip.transform.position - zipWidthSide;
        // draw the vision cone
        Handles.color = new Color(1f, 0f, 0, 1f);
        Handles.DrawLine(zip.transform.position, targetPos1, 4f);
        Handles.DrawLine(zip.transform.position, targetPos2, 4f);
    }
}
#endif
