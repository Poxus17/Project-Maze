using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Tests : MonoBehaviour
{
    [SerializeField] GameObject notPrefab;
    public void Test()
    {
        Instantiate(notPrefab, Vector3.zero, new Quaternion(0,0,0,0));
    }
}
