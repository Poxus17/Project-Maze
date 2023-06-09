using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionHandler : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] StringVariable currentDetectionText;
    [SerializeField] float detectionRange;

    [Space(5)]
    [Header("LockedState")]
    [SerializeField] BoolVariable interactionAllowed;
    [SerializeField] StringVariable lockedStateDetectionText;
    [SerializeField] GameEvent lockStateEvent;

    Vector3 viewportRaypoint;
    int castMask;

    IInteractable detectedObject;

    private void Start()
    {
        castMask = LayerMask.GetMask("Interaction");
        viewportRaypoint = new Vector3(0.5f, 0.5f, 0);
        interactionAllowed.value = true;
        currentDetectionText.value = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!interactionAllowed.value)
        {
            currentDetectionText.value = lockedStateDetectionText.value;
            return;
        }
        else if(currentDetectionText.value == lockedStateDetectionText.value)
        {
            currentDetectionText.value = "";
        }


        Ray ray = Camera.main.ViewportPointToRay(viewportRaypoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, detectionRange))
        {
            if(hit.collider.gameObject.tag == "Interact")
            {
                if (detectedObject == null)
                    detectedObject = hit.collider.gameObject.GetComponent<IInteractable>();
                currentDetectionText.value = detectedObject.GetInteractionText();
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
        if (!context.started)
            return;
        else if (!interactionAllowed.value)
        {
            lockStateEvent.Raise();
        }
        else if (detectedObject != null && context.started)
        {
            detectedObject.Interact();
        }
    }
}

public interface IInteractable
{
    void Interact();

    string GetInteractionText();
}



