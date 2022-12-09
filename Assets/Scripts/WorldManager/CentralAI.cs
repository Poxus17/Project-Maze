using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CentralAI : MonoBehaviour
{
    [SerializeField] LayerMask wallsMask;
    [SerializeField] float wallReductionPercent;
    [SerializeField] KellekHuntController kellek;

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
        #region Load Roam managers

        roamManagers = new List<AiRoamManager>();
        var findRoamManagers = FindObjectsOfType<AiRoamManager>();
        foreach(var roamManager in findRoamManagers)
        {
            if(roamManager != null)
            {
                roamManagers.Add(roamManager);
            }
        }

        Listeners = new List<AiListenerController>();
        var listeners = FindObjectsOfType<AiListenerController>();
        foreach(var listener in listeners)
        {
            if(listener != null)
            {
                Listeners.Add(listener);
            }
        }

        #endregion

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

            //Debug.Log(NoiseReduction(level, hits.Length, (distance / listener.range)));
            Debug.DrawRay(listener.transform.position, noisePosition - listener.transform.position);
            Debug.Log("Noise through " + hits.Length + " walls");

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
        kellek.RequestShakeoff();
    }


    public void ShakeoffConfirmed()
    {
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
        foreach(AiRoamManager rm in roamManagers)
        {
            rm.LoadRoamData(1, SectionsManager.instance.currentSection);
        }

        //FIX THIS SHIT
        if(!spawning)
            StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {
        spawning = true;
        yield return new WaitForSeconds(Random.Range(kellek._minSpawnTime, kellek._maxSpawnTime));
        kellek.SpawnIn();
        spawning = false;
    }

    private void OnDisable()
    {
        roamManagers.Clear();
        Listeners.Clear();
    }
}
