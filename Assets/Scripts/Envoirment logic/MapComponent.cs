using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapComponent : IndexedConsumable
{
    [SerializeField] int mapIndex;
    [SerializeField] BoolArrayVariable collectedMapPieces;

    public void CollectMapPiece()
    {
        try{
            collectedMapPieces.value[mapIndex] = true;
            UIManager.Instance.LaunchUIComponent(4);
            RegisterAsConsumed();
            gameObject.SetActive(false);
        }
        catch(System.Exception e){
            UI_TextDisplay.Instance.DisplayText("Error: " + e.Message, 5f);
        }
        
    }
}
