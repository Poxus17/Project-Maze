using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CentralAI : MonoBehaviour
{
    [SerializeField] LayerMask wallsMask;
    [SerializeField] float wallReductionPercent;
    [SerializeField] KellekHuntController kellek;
    [SerializeField] FloatVariable itemCount;
    [SerializeField] float kellekItemCount;

    [System.NonSerialized]
    public GameObject player;

    List<AiRoamManager> roamManagers;
    List<AiListenerController> Listeners;

    bool spawning;

    public static CentralAI Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        roamManagers = new List<AiRoamManager>();
        Listeners = new List<AiListenerController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void BroadcastNoise(float level, Vector3 noisePosition)
    {
        foreach(var listener in Listeners)
        {
            var distance = Vector3.Distance(listener.gameObject.transform.position, noisePosition);

            if (distance > listener.range)
                continue;

            var ray = new Ray(listener.transform.position, noisePosition - listener.transform.position);
            var range = Vector3.Distance(noisePosition, listener.transform.position);
            RaycastHit[] hits = Physics.RaycastAll(ray, range, wallsMask);
            
            Debug.DrawRay(listener.transform.position, noisePosition - listener.transform.position);

            var reducedNoise = NoiseReduction(level, hits.Length, (distance / listener.range));
            listener.GetNoise(reducedNoise);
        }
    }

    float NoiseReduction(float noise, int walls, float distanceFactor)
    {
        var redSqr = 100 - Mathf.Pow(noise, 2);
        var redProfile = Mathf.Sqrt(redSqr) / 10;

        var reduction = redProfile * distanceFactor * wallReductionPercent * walls;

        return noise * (1 - reduction);
    }

    //Ask kellek hunt controller to start shakeoff
    public void CommenseKellekShakeoff()
    {
        Debug.Log("Commense Kellek Shakeoff");
        if(SectionsManager.instance.currentSection != 0)
            kellek.RequestShakeoff();
    }


    public void ShakeoffConfirmed()
    {
        Debug.Log("Shakeoff Confirmed");
        SpawnInRing();
    }

    public void TurnOffAi()
    {
        foreach(AiListenerController ai in Listeners)
        {
            //ai.gameObject.SetActive(false);
        }
    }

    public void SpawnInRing()
    {
        Debug.Log("Requested Spawn In Ring");
        if (itemCount.value < kellekItemCount)
            return;

        foreach(AiRoamManager rm in roamManagers)
        {
            rm.LoadRoamData(1, SectionsManager.instance.currentSection); 
        }

        if(spawning)
        {
            Debug.Log("Already spawning. Spawn request terminated.");
            return;
        }
            

        if(kellek.instantSpawn)
        {
            kellek.SpawnIn();
            return;
        }

        spawning = true;
        var spawnTimer = Random.Range(kellek._minSpawnTime, kellek._maxSpawnTime);
        Debug.Log("He's coming in " + spawnTimer);
        GlobalTimerManager.instance.RegisterForTimer(SpawnKellek, spawnTimer);
    }

    private void SpawnKellek(){
        Debug.Log("Attempting to spawn Kellek");

        if(SectionsManager.instance.currentSection == 0)
        {
            Debug.Log("No Kellek section detected. Terminating spawn request.");
        }

        Debug.Log("Spawn confimed within CentralAI. Spawning Kellek.");
        kellek.SpawnIn();
        spawning = false;
    }

    private void OnDisable()
    {
        roamManagers.Clear();
        Listeners.Clear();
    }

    public void FindKellek(){
        kellek = FindObjectOfType<KellekHuntController>();

        roamManagers.Clear();
        var findRoamManagers = FindObjectsOfType<AiRoamManager>();
        foreach(var roamManager in findRoamManagers)
        {
            if(roamManager != null)
            {
                roamManagers.Add(roamManager);
            }
        }

        Listeners.Clear();
        var listeners = FindObjectsOfType<AiListenerController>();
        foreach(var listener in listeners)
        {
            if(listener != null)
            {
                Listeners.Add(listener);
            }
        }
    }
}
