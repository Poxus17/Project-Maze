using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MapManager : UIComponent
{
    [SerializeField] GameObject[] mapPieces;
    [SerializeField] BoolArrayVariable collectedMapParts;

    public void CollectMapPiece(int pieceIndex)
    {
        collectedMapParts.value[pieceIndex] = true;
    }

    public void LaunchMap()
    {
        for(int i = 0; i < mapPieces.Length; i++)
        {
            try
            {
                mapPieces[i].SetActive(
                collectedMapParts.value[i]);
            }
            catch(System.Exception e)
            {
                Debug.LogError(e.Message);
                Debug.Log(i);
            }
            
        }
    }

    public override void PersonalEventBindings()
    {
        LaunchComponentPersonalEvents += LaunchMap;
    }
}
