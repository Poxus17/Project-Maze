using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Debug_DrawAxis : MonoBehaviour
{
    [SerializeField] float length = 1f;
    [SerializeField] bool x = true;
    [SerializeField] bool y = true;
    [SerializeField] bool z = true;

    void Update(){
        if(x) Debug.DrawLine(transform.position, transform.position + transform.right * length, Color.red);
        if(y) Debug.DrawLine(transform.position, transform.position + transform.up * length, Color.green);
        if(z) Debug.DrawLine(transform.position, transform.position + transform.forward * length, Color.blue);
    }
}
