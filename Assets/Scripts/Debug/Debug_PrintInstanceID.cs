using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_PrintInstanceID : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_EDITOR
        Debug.Log("Instance ID: " + gameObject.GetInstanceID()+"\nThis information is brought to you by Debug_PrintInstanceID");
        #endif
    }
}
