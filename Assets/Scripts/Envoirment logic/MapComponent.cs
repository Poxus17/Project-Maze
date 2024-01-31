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

            SaveManager.instance.SaveAbsoluteData();

            gameObject.SetActive(false);
            
        }
        catch(System.Exception e){
            Debug.LogError("Error message: " + e.Message);
        }
        
    }
}
