using UnityEngine;

[CreateAssetMenu(menuName = "Announcer Variables/Vector3 Announcer Variable")]
public class Vector3AnnouncerVariable : Vector3Variable
{
    public GameEvent announceEvent;

    public void AnnounceSet(Vector3 newValue)
    {
        value = newValue;
        announceEvent.Raise();
    }

    public void RaiseEvent() {announceEvent.Raise();}

    new public void ParseInput(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(!context.performed)
            return;

        var inputVal = context.ReadValue<Vector2>();
        value = new Vector3(inputVal.x, inputVal.y, 0);
        announceEvent.Raise();
    }
}
