using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class ObjectRaycast : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] UnityEventGameobject onObjectDetected;

    public void Raycast()
    {
        var mouseViewportPos = Camera.main.ScreenToViewportPoint(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
        Ray ray = Camera.main.ViewportPointToRay(mouseViewportPos);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            onObjectDetected.Invoke(hit.collider.gameObject);
        }
    }

}

public class UnityEventGameobject : UnityEvent<GameObject> { }
