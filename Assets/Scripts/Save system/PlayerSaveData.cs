using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData
{
    public bool newSave;
    public float[] position;
    public int[] pastItemInventoryContents;
    public int[] placedPastItems;

    public PlayerSaveData()
    {
        Vector3 playerPos = CentralAI.Instance.player.transform.position;

        position = new float[3];
        position[0] = playerPos.x;
        position[1] = playerPos.y;
        position[2] = playerPos.z;


    }
}
