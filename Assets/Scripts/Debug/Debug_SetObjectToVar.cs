using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_SetObjectToVar : MonoBehaviour
{
    [SerializeField] BoolVariable setVar;
    [SerializeField] bool reverse;

    private void Start()
    {
        gameObject.SetActive(reverse ? !setVar.value : setVar.value);
    }
}
