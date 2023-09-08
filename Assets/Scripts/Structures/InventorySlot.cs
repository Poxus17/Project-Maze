using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] CanvasGroup canvasGroup; //canvasGroup
    [SerializeField] Button button; //button.
    [SerializeField] Image icon; // Item icon
    [SerializeField] Image overlay; // Hover overlay image
    [SerializeField] TMP_Text text; //text

    bool isPopulated = false;
    string objectName;

    public void PopulateSlot(PastObjectData data)
    {
        isPopulated = true;

        icon.enabled = true;
        icon.sprite = data.icon;

        objectName = data.name;
        text.text = objectName;
        
    }

    public void ClearSlot()
    {
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

        canvasGroup.alpha = 0;
    }

    public void ChooseInventorySlot()
    {
        if(isPopulated)
            InventoryManager.Instance.InspectFromInventory(objectName);
    }
}
