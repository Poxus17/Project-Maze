using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkedZoneComponent : IndexedConsumable
{
    [SerializeField] int zoneIndex;
    [SerializeField] BoolArrayVariable visitedMarkers;

    public void MarkZone(){
        visitedMarkers.value[zoneIndex] = true;
        RegisterAsConsumed();
    }
}
