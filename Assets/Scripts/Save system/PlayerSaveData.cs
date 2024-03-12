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
    public int sceneIndex;
    public int sectionIndex;

    public PlayerSaveData(GameObject player, bool[] eventsMemory, bool[] bvalValues, int sceneIndex, int sectionIndex)
    {
        Vector3 playerPos = player.transform.position;

        position = new float[3];
        position[0] = playerPos.x;
        position[1] = playerPos.y;
        position[2] = playerPos.z;

        pastItemInventoryContents = ItemsManager.instance.GetInventoryData();
        placedPastItems = ItemsManager.instance.GetPlacementData();
        eventsToTrigger = eventsMemory;
        bvals = bvalValues;
        this.sceneIndex = sceneIndex;
        this.sectionIndex = sectionIndex;
    }
}
