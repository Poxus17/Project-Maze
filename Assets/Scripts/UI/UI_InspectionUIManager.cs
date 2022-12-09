using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UI_InspectionUIManager : MonoBehaviour
{
    [SerializeField] GameObject inspectionCanvas;
    [SerializeField] Transform inspectionParent;
    [SerializeField] TMP_Text inspectionText;
    [SerializeField] AudioSource inspectionAudioSource;
    [SerializeField] PastObjectPacketVariable inspectionPacket;

    GameObject inspectionObject;

    public void SetInspectionUIActive(bool active)
    {
        inspectionCanvas.SetActive(active);
    }
    
    public void SetInspectionUI()
    {
        for(int i =0; i< inspectionParent.childCount; i++)
        {
            Destroy(inspectionParent.GetChild(i).gameObject);
        }

        inspectionObject = Instantiate(inspectionPacket.Value.gameObject, inspectionParent);
        inspectionText.text = inspectionPacket.Value.data.transcript;
        inspectionObject.transform.localScale = inspectionPacket.Value.scale;
        inspectionObject.transform.eulerAngles = inspectionPacket.Value.eularRotation;
        inspectionObject.transform.localPosition = Vector3.zero;
    }
}
