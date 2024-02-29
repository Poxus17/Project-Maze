using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_VarPrinter : MonoBehaviour
{
    public FloatVariable obj;
    public bool printOnTick;

    private void Update()
    {
        if (printOnTick)
            Debug.Log(obj.value);
    }
}
