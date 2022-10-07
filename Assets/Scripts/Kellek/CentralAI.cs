using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CentralAI : MonoBehaviour
{
    [SerializeField] AiListenerController[] Listeners;
    [SerializeField] LayerMask wallsMask;

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
            if (Vector3.Distance(listener.gameObject.transform.position, noisePosition) > listener.range)
                continue;


            //conversion logic here

            //Debug.Log(Vector3.Distance(listener.gameObject.transform.position, noisePosition));
            var ray = new Ray(listener.transform.position, noisePosition - listener.transform.position);
            var range = Vector3.Distance(noisePosition, listener.transform.position);

            RaycastHit[] hits = Physics.RaycastAll(ray, range,wallsMask);

            Debug.Log(hits.Length);
            Debug.DrawRay(listener.transform.position, noisePosition - listener.transform.position);
            listener.GetNoise(level);
        }
    }

}
