using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CentralAI : MonoBehaviour
{
    [SerializeField] AiListenerController[] Listeners;
    [SerializeField] LayerMask wallsMask;
    [SerializeField] float wallReductionPercent;

    public GameObject player;

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

    public void BroadcastNoise(float level, Vector3 noisePosition)
    {
        foreach(var listener in Listeners)
        {
            var distance = Vector3.Distance(listener.gameObject.transform.position, noisePosition);

            if (distance > listener.range)
                continue;

            var ray = new Ray(listener.transform.position, noisePosition - listener.transform.position);
            var range = Vector3.Distance(noisePosition, listener.transform.position);
            RaycastHit[] hits = Physics.RaycastAll(ray, range,wallsMask);

            //Debug.Log(NoiseReduction(level, hits.Length, (distance / listener.range)));
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

}
