using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
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

    public void Interact()
    {
        if (detectedObject != null)
        {
            detectedObject.Interact();
        }
    }
}

public interface IInteractable
{
    void Interact();
}

