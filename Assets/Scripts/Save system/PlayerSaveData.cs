using UnityEngine;

[System.Serializable]
public class PlayerSaveData
{
    public bool newSave;
    public float[] position;
    public bool[] pastItemInventoryContents;
    public bool[] placedPastItems;
    public bool[] eventsToTrigger;
    public bool[] bvals;
    //public bool[] collectdMapPieces;
    //public int[] consumableIndexes;

    public PlayerSaveData(GameObject player, bool[] eventsMemory, bool[] bvalValues /*, bool[] mapMemory, int[] consumedIndexes*/)
    {
        Vector3 playerPos = player.transform.position;

        position = new float[3];
        position[0] = playerPos.x;
        position[1] = playerPos.y;
        position[2] = playerPos.z;

        pastItemInventoryContents = PastObjectManager.instance.GetInventoryData();
        placedPastItems = PastObjectManager.instance.GetPlacementData();
        eventsToTrigger = eventsMemory;
        bvals = bvalValues;
        //collectdMapPieces = mapMemory;
        //consumableIndexes = consumedIndexes;
    }
}
