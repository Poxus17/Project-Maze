using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameEvent[] saveableEvents;
    [SerializeField] BoolVariable[] bvalsForMemory;
    [SerializeField] GameEvent varLoadEvent;
    [SerializeField] BoolArrayVariable mapIndex;
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
        LoadGame();
    }

    public void SaveGame()
    {
        PlayerSaveData playerData = new PlayerSaveData(player, eventsMemory, FormatBvalArrayForSave(), mapIndex.value);
        SaveSystem.SavePlayer(playerData);
        Debug.Log("game saved");
    }

    public void LoadGame()
    {
        PlayerSaveData data = SaveSystem.LoadPlayer();

        if (data == null)
        {
            eventsMemory = new bool[saveableEvents.Length];
            return;
        }
            

        player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);

        mapIndex.value = data.collectdMapPieces;

        #region Load item data
        PastObjectManager.instance.SetInventoryData(data.pastItemInventoryContents);
        PastObjectManager.instance.SetPlacedData(data.placedPastItems);
        PastObjectManager.instance.MatchItemObjectState();
        PastObjectManager.instance.CountItems();
        #endregion

        #region Call load events
        eventsMemory = data.eventsToTrigger;
        for(int i = 0; i<eventsMemory.Length; i++)
        {
            if (eventsMemory[i])
                saveableEvents[i].Raise();
        }
        #endregion

        #region Match map states
        // Get all instances of the map component in the scene
        var mapComponents = GameObject.FindObjectsOfType<MapComponent>();

        // Call MatchMapState on each instance
        foreach (var mapComponent in mapComponents)
        {
            mapComponent.MatchMapState();
        }
        #endregion

        #region Load Bvals

        for(int i = 0; i < data.bvals.Length; i++)
        {
            bvalsForMemory[i].value = data.bvals[i];
        }

        varLoadEvent.Raise();
        #endregion

        Debug.Log("game loaded");
    }

    public void DeleteSave()
    {
        SaveSystem.DeleteSaveFile();
    }

    public void registerSavedEvent(int eventIndex)
    {
        eventsMemory[eventIndex] = true;
    }

    bool[] FormatBvalArrayForSave()
    {
        bool[] formatedBvals = new bool[bvalsForMemory.Length];

        for(int i =0; i< formatedBvals.Length; i++)
        {
            formatedBvals[i] = bvalsForMemory[i].value;
        }

        return formatedBvals;
    }
}

