using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MapManager : UIComponent
{
    [SerializeField] GameObject[] mapPieces;
    [SerializeField] BoolArrayVariable collectedMapParts;
    [SerializeField] GameObject noMapText;

    public void CollectMapPiece(int pieceIndex)
    {
        collectedMapParts.value[pieceIndex] = true;
    }

    public void LaunchMap()
    {
        noMapText.SetActive(true);
        for(int i = 0; i < mapPieces.Length; i++)
        {
            try
            {
                var mapPieceActive = collectedMapParts.value[i];
                mapPieces[i].SetActive(mapPieceActive);

                if (mapPieceActive)
                    noMapText.SetActive(false);
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
