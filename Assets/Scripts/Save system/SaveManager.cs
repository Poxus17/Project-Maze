using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameEvent[] saveableEvents;
    bool[] eventsMemory;

    public static SaveManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        eventsMemory = new bool[saveableEvents.Length];
        LoadGame();
    }

    public void SaveGame()
    {
        SaveSystem.SavePlayer(player, eventsMemory);
        Debug.Log("game saved");
    }

    public void LoadGame()
    {
        PlayerSaveData data = SaveSystem.LoadPlayer();

        if (data == null)
            return;

        player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);

        PastObjectManager.instance.SetInventoryData(data.pastItemInventoryContents);
        PastObjectManager.instance.SetPlacedData(data.placedPastItems);
        PastObjectManager.instance.MatchItemObjectState();
        PastObjectManager.instance.CountItems();

        eventsMemory = data.eventsToTrigger;
        for(int i = 0; i<eventsMemory.Length; i++)
        {
            if (eventsMemory[i])
                saveableEvents[i].Raise();
        }

        Debug.Log("game loaded");
    }

    public void registerSavedEvent(int eventIndex)
    {
        eventsMemory[eventIndex] = true;
    }
}
