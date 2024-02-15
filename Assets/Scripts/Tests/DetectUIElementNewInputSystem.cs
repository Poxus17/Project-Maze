using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DetectUIElementNewInputSystem : MonoBehaviour
{
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;

    void Start()
    {
        eventSystem = EventSystem.current;
    }

    void Update()
    {
        // Check for a click using the new Input System
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            DetectUIElement();
        }
    }

    void DetectUIElement()
{
    pointerEventData = new PointerEventData(eventSystem)
    {
        position = Mouse.current.position.ReadValue()
    };

    List<RaycastResult> results = new List<RaycastResult>();
    eventSystem.RaycastAll(pointerEventData, results);

    if (results.Count > 0)
    {
        Debug.Log("Top Hit " + results[0].gameObject.name);
        // Now it only prints the name of the topmost UI element
    }
}

}
