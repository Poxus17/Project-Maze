using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapComponent : MonoBehaviour
{
    [SerializeField] int mapIndex;
    [SerializeField] BoolArrayVariable collectedMapPieces;

    public void CollectMapPiece()
    {
        collectedMapPieces.value[mapIndex] = true;
        UIManager.Instance.LaunchUIComponent(4);
        gameObject.SetActive(false);
    }

    public void MatchMapState(){
        gameObject.SetActive(!collectedMapPieces.value[mapIndex]);
    }
}
