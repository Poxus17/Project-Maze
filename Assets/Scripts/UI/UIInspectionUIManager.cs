using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UIInspectionUIManager : UIComponent
{
    [Space(5)]
    [Header("Inspector settings")]
    [Space(2)]
    [SerializeField] GameObject inspectionCanvas;
    [SerializeField] Transform inspectionParent;
    [SerializeField] TMP_Text inspectionText;
    [SerializeField] PastObjectData inspectionPacket;

    GameObject inspectionObject;

    public override void PersonalEventBindings()
    {
        LaunchComponentPersonalEvents += SetInspectionUI;
    }

    public void SetInspectionUI()
    {
        inspectionText.text = inspectionPacket.transcript;
    }

    
}
