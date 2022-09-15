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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = active;
    }
    public void SetInspectionUI(PastObjectPacket packet)
    {
        inspectionText.text = packet.text;
        inspectionMeshFilter.mesh = packet.mesh;
        inspectionRenderer.materials = packet.mats;
        inspectionRenderer.transform.localScale = packet.scale;
    }
}
