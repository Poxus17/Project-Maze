using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UI_InspectionUIManager : MonoBehaviour
{
    [SerializeField] GameObject inspectionCanvas;
    [SerializeField] TMP_Text inspectionText;
    [SerializeField] MeshFilter inspectionMeshFilter;
    [SerializeField] MeshRenderer inspectionRenderer;

    public void SetInspectionUIActive(bool active)
    {
        inspectionCanvas.SetActive(active);
        WorldEventDispatcher.instance.SetUIActive(active);
    }
    
    public void SetInspectionUI(PastObjectData data)
    {
        inspectionText.text = data.transcript;
        inspectionMeshFilter.mesh = data.mesh;
        inspectionRenderer.materials = data.materials;
        inspectionRenderer.transform.localScale = data.scale;
        inspectionRenderer.transform.eulerAngles = data.eularRotation;
    }
}
