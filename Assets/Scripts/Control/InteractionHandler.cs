using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionHandler : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] StringVariable currentDetectionText;
    [SerializeField] float detectionRange;
    [SerializeField] LayerMask interactionMask;
    [SerializeField] StringVariable tagString;
    [SerializeField] BoolVariable onUi;

    [Space(5)]
    [Header("LockedState")]
    [SerializeField] BoolVariable interactionLockedState; // an alternative state of interaction detection. This one is a permenant option, until explicitly turned off
    [SerializeField] StringVariable lockedStateDetectionText;
    [SerializeField] GameEvent lockStateEvent;

    private LayerMask mask;
    Vector3 viewportRaypoint;
    int castMask;
    int lastDetectedId;
    bool exclusiveLocked; //True if currently in an interaction's exlusive time

    IInteractable interactableObject;
    EnvoirmentSoundEffectComponent detectedObject;

    private void Start()
    {
        castMask = LayerMask.GetMask("Interaction");
        viewportRaypoint = new Vector3(0.5f, 0.5f, 0);
        interactionLockedState.value = false;
        currentDetectionText.value = "";
        mask = interactionMask;
    }

    // Update is called once per frame
    void FixedUpdate()
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

        if(!PlayerCameraHandler.instance.isActive)
            return;
            
        //Typical raycast
        var mouseViewportPos = Camera.main.ScreenToViewportPoint(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
        Ray ray = Camera.main.ViewportPointToRay(mouseViewportPos);

        //Debug.DrawRay(ray.origin, ray.direction * detectionRange, Color.red);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, detectionRange, mask))
        {
            //Debug.Log("Hit " + hit.collider.gameObject);
            var hitObject = hit.collider.gameObject;
            if ( hitObject.tag == tagString.value)
            {
                var currentInstanceId = hitObject.GetInstanceID();

                if (interactableObject == null || lastDetectedId != currentInstanceId)
                {
                    interactableObject = hitObject.GetComponent<IInteractable>();
                    lastDetectedId = currentInstanceId;
                    currentDetectionText.value = interactableObject.GetInteractionText();
                }
            }
            /*else if(hitObject.tag == "Detect")
            {
                var currentInstanceId = hitObject.GetInstanceID();

                if (detectedObject == null || lastDetectedId != currentInstanceId)
                {
                    detectedObject = hitObject.GetComponent<EnvoirmentSoundEffectComponent>();
                    lastDetectedId = currentInstanceId;

                    if (!detectedObject.Detect())
                        detectedObject = null;
                }
            }*/
            else if (interactableObject != null || detectedObject != null)
            {
                ClearDetection();
            }
        }
        else if(interactableObject != null || detectedObject != null)
        {
            ClearDetection();
        }
    }

    public void Interact(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(context.started)
            Debug.Log("interaction initiated");

            
        if (!context.started || exclusiveLocked || onUi.value)
            return;
        else if (interactionLockedState.value)
        {
            Debug.Log("Interaction locked");
            lockStateEvent.Raise();
        }
        else if (interactableObject != null)
        {
            interactableObject.Interact();
            Debug.Log("Successfuly interacting with " + interactableObject);

            if (interactableObject.exclusiveTime > 0)
            {
                exclusiveLocked = true;
                GlobalTimerManager.instance.RegisterForTimer(() => { exclusiveLocked = false; }, interactableObject.exclusiveTime);
            }

            ClearDetection();
        }
        else{
            Debug.Log("No interactable object detected");
        }
    }

    private void ClearDetection()
    {
        interactableObject = null;
        currentDetectionText.value = "";

        if(detectedObject != null)
            detectedObject.Lose();

        detectedObject = null;
    }
}

public interface IInteractable
{
    float exclusiveTime { get; set; } //The amount of time after the interaction when no other interaction can occure

    void Interact();

    string GetInteractionText();

    bool InteractionAllowed();
}



