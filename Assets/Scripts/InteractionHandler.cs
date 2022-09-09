using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    Vector3 viewportRaypoint;
    int castMask;



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
            print("I'm looking at " + hit.transform.name);

    }
}

public interface IInteractable
{
    void Interact();
}
