using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] StringVariable currentDetectionText;

    Vector3 viewportRaypoint;
    int castMask;

    IInteractable detectedObject;

    private void Start()
    {
        castMask = LayerMask.GetMask("Interaction");
        viewportRaypoint = new Vector3(0.5f, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(viewportRaypoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5000))
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
        if (detectedObject != null && context.started)
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



