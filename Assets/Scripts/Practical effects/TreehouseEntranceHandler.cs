using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreehouseEntranceHandler : MonoBehaviour
{
    [SerializeField] Vector3 treehouseBase;
    [SerializeField] Vector3 treehouseTop;
    [SerializeField] float transitionSpeed;
    [SerializeField] bool startUp;
    public BoolVariable inTreehouse;

    private void Start()
    {
        inTreehouse.value = startUp;
    }

    public void OnUseTreehouseDoor()
    {

        inTreehouse.value = inTreehouse.value ? false : true;
    }
}
