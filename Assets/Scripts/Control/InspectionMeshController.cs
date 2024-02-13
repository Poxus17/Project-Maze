using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InspectionMeshController : MonoBehaviour
{
    [SerializeField] GameObject inspectionMesh;
    [SerializeField] float deltaRotationRatio;
    [SerializeField] BoolVariable rightClickVariable;
    [SerializeField] Vector3Variable parsedInputMouseDelta;
    [SerializeField] PastObjectData inspectionPacket;

    //bool rightClick = false;
    Vector2 currentMousePos;

    public void MoveInspection()
    {
        if (rightClickVariable.value)
        {
            Vector2 value = parsedInputMouseDelta.value;
            if (currentMousePos == Vector2.zero)
                currentMousePos = value;
            var delta = currentMousePos - value;
            delta *= deltaRotationRatio;
            inspectionMesh.transform.Rotate(-delta.y, delta.x, 0, Space.World);

            currentMousePos = value;
        }
        else
        {
            currentMousePos = Vector2.zero;
        }
    }

    public void EnterInspection(){
        for(int i =0; i< transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        GameObject inspectionObject = Instantiate(inspectionPacket.itemPrefab, transform);
        
        inspectionObject.transform.localPosition = Vector3.zero;        
    }
}
