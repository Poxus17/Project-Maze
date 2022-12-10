using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] InteractionEvent EnterInspection;
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
        if (Physics.Raycast(ray, out hit, 10000, castMask))
            detectedObject = hit.collider.gameObject.GetComponent<IInteractable>();
        else
            detectedObject = null; 

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
}

public class InteractionEvent : UnityEvent<GameObject> { }


