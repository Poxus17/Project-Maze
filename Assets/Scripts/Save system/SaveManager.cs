using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

public class SaveManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameEvent[] saveableEvents;
    [SerializeField] BoolVariable[] bvalsForMemory;
    [SerializeField] GameEvent varLoadEvent;
    [SerializeField] BoolArrayVariable mapIndex;
    bool[] eventsMemory;
    List<int> consumableIndexes;

    public bool isLoading = false;

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

        consumableIndexes = new List<int>();
    }

    private void Start()
    {
        Profiler.BeginSample("SaveManager.LoadGame()");
        LoadGame();
        Profiler.EndSample();
    }

    public void SaveGame()
    {
        PlayerSaveData playerData = new PlayerSaveData(player, eventsMemory, FormatBvalArrayForSave(), mapIndex.value, FormatConsumablesForSave());
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
        
        isLoading = true;

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

        #region Remove consumed indexed items

        consumableIndexes = data.consumableIndexes.ToList<int>(); //Re-save all the old indexes

        var consumables = FindObjectsOfType<IndexedConsumable>();
        foreach(IndexedConsumable consumable in consumables)
        {
            consumable.KillMe(data.consumableIndexes);
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

        isLoading = false;
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

    public void RegisterConsumable(int indexCosnumed)
    {
        consumableIndexes.Add(indexCosnumed);
    }

    int[] FormatConsumablesForSave()
    {
        return consumableIndexes.ToArray();
    }
}

