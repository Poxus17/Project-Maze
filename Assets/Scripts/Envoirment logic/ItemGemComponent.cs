using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ItemGemComponent : MonoBehaviour
{
    [SerializeField] Material onMat;
    [SerializeField] BoolVariable isOn;

    MeshRenderer meshRenderer; //Mesh renderer.

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        CheckTurnOn();
        Debug.Log("ItemGemComponent OnEnable");
    }

    public void CheckTurnOn()
    {
        if (isOn.value)
            meshRenderer.material = onMat;
    }
}
