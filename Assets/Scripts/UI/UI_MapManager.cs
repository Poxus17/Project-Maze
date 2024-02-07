using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UI_MapManager : UIComponent
{
    [SerializeField] GameObject[] mapPieces;
    [SerializeField] BoolArrayVariable collectedMapParts;
    [SerializeField] BoolArrayVariable visitedMarkers;
    [SerializeField] GameObject noMapText;
    [SerializeField] AudioClip mapSe;
    [SerializeField] MapMarker[] markers;

    public void LaunchMap()
    {
        noMapText.SetActive(true);
        MusicMan.instance.PlaySE(mapSe);
        bool hasMap = false;
        for(int i = 0; i < mapPieces.Length; i++)
        {
            var mapPieceActive = collectedMapParts.value[i];
            mapPieces[i].SetActive(mapPieceActive);

            if (hasMap)
                continue;

            if (!mapPieceActive)
                continue;

            noMapText.SetActive(false);
            hasMap = true;
        }
        for(int j = 0; j < markers.Length; j++)
        {
            var markerActive = visitedMarkers.value[j] && collectedMapParts.value[markers[j].sectionIndex];
            markers[j].marker.SetActive(markerActive);
        }
    }

    public override void PersonalEventBindings()
    {
        LaunchComponentPersonalEvents += LaunchMap;
    }
}

[System.Serializable]
class MapMarker{
    public int sectionIndex;
    public GameObject marker;
}
