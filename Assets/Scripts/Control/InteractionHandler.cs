using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionHandler : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] StringVariable currentDetectionText;
    [SerializeField] float detectionRange;
    [SerializeField] LayerMask mask;

    [Space(5)]
    [Header("LockedState")]
    [SerializeField] BoolVariable interactionLockedState; // an alternative state of interaction detection. This one is a permenant option, until explicitly turned off
    [SerializeField] StringVariable lockedStateDetectionText;
    [SerializeField] GameEvent lockStateEvent;

    Vector3 viewportRaypoint;
    int castMask;
    int lastDetectedId;
    bool exclusiveLocked; //True if currently in an interaction's exlusive time

    IInteractable detectedObject;

    private void Start()
    {
        castMask = LayerMask.GetMask("Interaction");
        viewportRaypoint = new Vector3(0.5f, 0.5f, 0);
        interactionLockedState.value = false;
        currentDetectionText.value = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Handle locked state
        if (interactionLockedState.value)
        {
            currentDetectionText.value = lockedStateDetectionText.value;
            return;
        }
        else if(currentDetectionText.value == lockedStateDetectionText.value)
        {
            currentDetectionText.value = "";
        }

        //Typical raycast
        Ray ray = Camera.main.ViewportPointToRay(viewportRaypoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, detectionRange,mask))
        {
            var hitObject = hit.collider.gameObject;
            if ( hitObject.tag == "Interact")
            {
                var currentInstanceId = hitObject.GetInstanceID();

                if (detectedObject == null || lastDetectedId != currentInstanceId)
                {
                    detectedObject = hit.collider.gameObject.GetComponent<IInteractable>();
                    lastDetectedId = currentInstanceId;
                    currentDetectionText.value = detectedObject.GetInteractionText();
                }
            }
            else if (detectedObject != null)
            {
                detectedObject = null;
                currentDetectionText.value = "";
            }
        }
        else if(detectedObject != null)
        {
            detectedObject = null;
            currentDetectionText.value = "";
        }
    }

    public void Interact(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!context.started || exclusiveLocked)
            return;
        else if (interactionLockedState.value)
        {
            lockStateEvent.Raise();
        }
        else if (detectedObject != null)
        {
            detectedObject.Interact();

            if (detectedObject.exclusiveTime > 0)
                StartCoroutine(PlayExclusiveTime(detectedObject.exclusiveTime));

            detectedObject = null;
        }
    }

    IEnumerator PlayExclusiveTime(float time)
    {
        exclusiveLocked = true;
        yield return new WaitForSeconds(time);
        exclusiveLocked = false;
    }
}

public interface IInteractable
{
    float exclusiveTime { get; set; } //The amount of time after the interaction when no other interaction can occure

    void Interact();

    string GetInteractionText();

    bool InteractionAllowed();
}



