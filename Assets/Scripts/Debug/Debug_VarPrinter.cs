using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_VarPrinter : MonoBehaviour
{
    public PastObjectData obj;
    public bool printOnTick;

    private void Update()
    {
        if (printOnTick)
            Debug.Log(obj.name);
    }
}
