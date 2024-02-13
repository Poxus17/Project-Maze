using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Variables/Vector3 Variable")]
public class Vector3Variable : ScriptableObject
{
    public Vector3 value;

    public void ParseInput(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(!context.performed)
            return;

        var inputVal = context.ReadValue<Vector2>();
        value = new Vector3(inputVal.x, inputVal.y, 0);
    }
}
