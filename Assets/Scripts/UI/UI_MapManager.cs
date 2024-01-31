using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MapManager : UIComponent
{
    [SerializeField] GameObject[] mapPieces;
    [SerializeField] BoolArrayVariable collectedMapParts;
    [SerializeField] GameObject noMapText;
    [SerializeField] AudioClip mapSe;

    public void LaunchMap()
    {
        noMapText.SetActive(true);
        MusicMan.instance.PlaySE(mapSe);
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
                UI_TextDisplay.Instance.DisplayText("Error message: " + e.Message, 5f);
            }
            
        }
    }

    public override void PersonalEventBindings()
    {
        LaunchComponentPersonalEvents += LaunchMap;
    }
}
