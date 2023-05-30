using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_FlipFlop : MonoBehaviour
{
    public void FlipFlopObject(GameObject gObject)
    {
        gObject.SetActive(!gObject.activeSelf);
    }
}
