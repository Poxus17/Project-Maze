using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ItemGemComponent : MonoBehaviour
{
    [SerializeField] Material onMat;
    [SerializeField] BoolVariable isOn;

    MeshRenderer meshRenderer; //Mesh renderer.

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void CheckTurnOn()
    {
        if (isOn.value)
            meshRenderer.material = onMat;
    }
}
