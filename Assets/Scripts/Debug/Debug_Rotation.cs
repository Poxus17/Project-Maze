using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Rotation : MonoBehaviour
{
    [SerializeField] float rotationRate;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, rotationRate * Time.deltaTime, 0);
    }
}
