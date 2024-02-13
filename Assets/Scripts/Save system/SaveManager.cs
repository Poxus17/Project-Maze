using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

public class SaveManager : MonoBehaviour
{
    [SerializeField] GameEvent[] saveableEvents;
    [SerializeField] BoolVariable[] bvalsForMemory;
    [SerializeField] GameEvent varLoadEvent;
    [SerializeField] BoolArrayVariable mapIndex;
    [SerializeField] BoolArrayVariable visitedMarkers;
    [SerializeField] FloatVariable[] fvalsForMemory;

    [SerializeField] bool debugOverridePlayerLoad;
    [SerializeField] bool debugOverrideAbsoluteLoad;
    [SerializeField] int defaultSceneIndex;

    bool[] eventsMemory;
    List<int> consumableIndexes;
    private PlayerSaveData data;
    private AbsoluteData absoluteData;
    private GameObject player;

    [NonSerialized] public bool isLoading = false;

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
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        Profiler.BeginSample("SaveManager.LoadGame()");
        LoadGame();
        Profiler.EndSample();
    }

    public void SaveGame()
    {
        PlayerSaveData playerData = new PlayerSaveData(player, eventsMemory, FormatBvalArrayForSave(), PersistantManager.instance.ActiveSceneIndex, SectionsManager.instance.currentSection);
        SaveSystem.SavePlayer(playerData);
        Debug.Log("game saved");
    }

    public void SaveAbsoluteData(){
        AbsoluteData absoluteData = new AbsoluteData(mapIndex.value, visitedMarkers.value, FormatConsumablesForSave(), FormatFvalArrayForSave());
        SaveSystem.SaveAbsoluteData(absoluteData);
        Debug.Log("absolute data saved");
    }

    public void LoadGame()
    {
        LoadAbsoluteData();
        LoadPlayerData();
    }

    private void LoadPlayerData(){

        if(debugOverridePlayerLoad)
            return;

        data = SaveSystem.LoadPlayer();
        
        if (data == null)
        {
            eventsMemory = new bool[saveableEvents.Length];
            PersistantManager.instance.MidLoadSceneSet(defaultSceneIndex);
            return;
        }
        
        isLoading = true;

        player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);

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


        #region Load Bvals

        for(int i = 0; i < data.bvals.Length; i++)
        {
            bvalsForMemory[i].value = data.bvals[i];
        }

        varLoadEvent.Raise();
        #endregion

        Debug.Log("game loaded");

        isLoading = false;

        PersistantManager.instance.MidLoadSceneSet(data.sceneIndex);
        SectionsManager.instance.SetSection(data.sectionIndex);
    }

    private void LoadAbsoluteData(){

        if(debugOverrideAbsoluteLoad)
            return;

        absoluteData = SaveSystem.LoadAbsoluteData();

        if(absoluteData == null)
            return;
        
        mapIndex.value = absoluteData.collectdMapPieces;
        visitedMarkers.value = absoluteData.markedZones;

        RemoveConsumedIndexedObjects();

        #region Load fvals
        for(int i = 0; i < absoluteData.fvalValues.Length; i++)
        {
            fvalsForMemory[i].value = absoluteData.fvalValues[i];
        }
        #endregion
    }

    public void DeathLoadCheck(){
        if(LoadFlags.deathLoad){
            LoadPlayerData();
            LoadFlags.deathLoad = false;
        }
        
    }

    public void DeleteSave()
    {
        #if UNITY_EDITOR
        SaveSystem.DeleteSaveFile();
        #endif
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

    float[] FormatFvalArrayForSave()
    {
        float[] formatedFvals = new float[fvalsForMemory.Length];

        for(int i =0; i< formatedFvals.Length; i++)
        {
            formatedFvals[i] = fvalsForMemory[i].value;
        }

        return formatedFvals;
    }

    public void RegisterConsumable(int indexCosnumed)
    {
        consumableIndexes.Add(indexCosnumed);
    }

    int[] FormatConsumablesForSave()
    {
        return consumableIndexes.ToArray();
    }

    public void RemoveConsumedIndexedObjects(){

        if(absoluteData == null)
            return;

        consumableIndexes = absoluteData.consumableIndexes.ToList<int>(); //Re-save all the old indexes

            var consumables = FindObjectsOfType<IndexedConsumable>();
            foreach(IndexedConsumable consumable in consumables)
            {
                consumable.KillMe(absoluteData.consumableIndexes);
            }
    }
}

