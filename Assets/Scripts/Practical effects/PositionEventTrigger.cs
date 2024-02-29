using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionEventTrigger : MonoBehaviour //UNFINISED TOOL
{
    [Header("Select Positions")]
    [SerializeField] bool xCheck;
    [SerializeField] bool yCheck;
    [SerializeField] bool zCheck;

    [Space(10)]
    [Header("Position triggers")]
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;

    [Space(5)]
    [Header("Settings")] //actions are player then object
    [SerializeField] ECompareAction xAction;
    [SerializeField] ECompareAction yAction;
    [SerializeField] ECompareAction zAction;
    [SerializeField] float checkDistance = 50;

    [Space(5)]
    [Header("Event")]
    [SerializeField] UnityEngine.Events.UnityEvent FireEvent;


    Transform playerTransform;
    private void Start()
    {
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, CentralAI.Instance.player.transform.position) > checkDistance)
            return;

        if (CentralAI.Instance.player.transform.position.z > z)
            return;

        FireEvent.Invoke();
        this.enabled = false;
   }
}

public enum ECompareAction { More, Less}
