using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ITransmitterCompatible<string>
{
    [SerializeField] CanvasGroup canvasGroup; //canvasGroup
    [SerializeField] Button button; //button.
    [SerializeField] Image icon; // Item icon
    [SerializeField] Image overlay; // Hover overlay image
    [SerializeField] TMP_Text text; //text
    [SerializeField] AudioClip clip; //clip

    private bool isChosen = false;
    bool isPopulated = false;
    string objectName;

    private ValueTransmitter<string> transmitter;

    public void Init(ValueTransmitter<string> transmitter)
    {
        this.transmitter = transmitter;
    }

    public void PopulateSlot(StoreableItem data)
    {
        isPopulated = true;

        icon.enabled = true;
        icon.sprite = data.icon;

        objectName = data.name;
        text.text = objectName;
        
    }

    public void ClearSlot()
    {
        DeselectInventorySlot();
        isPopulated = false;

        icon.enabled = false;
        icon.sprite = null;

        objectName = "";
        text.text = objectName;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (!isPopulated)
            return;

        canvasGroup.alpha = 1;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (!isPopulated)
            return;

        if(isChosen)
            return;

        canvasGroup.alpha = 0;
    }

    public void ChooseInventorySlot()
    {
        if(!isPopulated)
            return;

        transmitter.SetValue(objectName);
        MusicMan.instance.PlaySE(clip);
        isChosen = true;
        canvasGroup.alpha = 1;
        transmitter.SubscribeOnChange(CheckSelected);
    }

    public void CheckSelected(){
        if(!isPopulated)
            return;

        if(transmitter.Value == objectName)
            return;

        DeselectInventorySlot();
        transmitter.UnsubscribeOnChange(CheckSelected);
    }

    public void DeselectInventorySlot()
    {
        isChosen = false;
        canvasGroup.alpha = 0;
    }
}
