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
        StartCoroutine(TreehouseTransition());
        inTreehouse.value = inTreehouse.value ? false : true;
    }

    IEnumerator TreehouseTransition()
    {
        Vector3 a, b;
        var alpha = 0f;

        if (inTreehouse.value == true)
        {
            a = treehouseTop; 
            b = treehouseBase;
        }
        else
        {
            a = treehouseBase;
            b = treehouseTop;
        }

        while (alpha < 1)
        {
            alpha += transitionSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(a, b, alpha);
            yield return null;
        }

        
    }
}
