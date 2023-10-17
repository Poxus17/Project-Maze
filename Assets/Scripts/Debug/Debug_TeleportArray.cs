using UnityEngine;

public class Debug_TeleportArray : MonoBehaviour
{
    public Vector3[] teleportLocations;
    private int currentLocationIndex = 0;

    private void Start()
    {
        // Initial safety check to make sure there's at least one location in the array
        if (teleportLocations.Length == 0)
        {
            Debug.LogWarning("No teleport locations set!");
            return;
        }

    }

    public void TeleportToNextLocation(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (teleportLocations.Length == 0) return;

        // Increment the index
        currentLocationIndex++;

        // If we're past the end of the array, loop back to the beginning
        if (currentLocationIndex >= teleportLocations.Length)
        {
            currentLocationIndex = 0;
        }

        TeleportToLocation(teleportLocations[currentLocationIndex]);
    }

    private void TeleportToLocation(Vector3 location)
    {
        transform.position = location;
    }
}
