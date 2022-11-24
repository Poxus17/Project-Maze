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

    GameObject inspectionObject;

    public void SetInspectionUIActive(bool active)
    {
        inspectionCanvas.SetActive(active);
        WorldEventDispatcher.instance.SetUIActive(active);

        if (active)
            inspectionAudioSource.Play();
        else
            inspectionAudioSource.Stop();
    }
    
    public void SetInspectionUI(PastObjectPacket packet)
    {
        for(int i =0; i< inspectionParent.childCount; i++)
        {
            Destroy(inspectionParent.GetChild(i).gameObject);
        }

        inspectionObject = Instantiate(packet.gameObject, inspectionParent);
        inspectionText.text = packet.data.transcript;
        inspectionObject.transform.localScale = packet.scale;
        inspectionObject.transform.eulerAngles = packet.eularRotation;
        inspectionObject.transform.localPosition = Vector3.zero;
    }
}
