using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityManager : MonoBehaviour
{
    [SerializeField] int targetFPS = 60;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = targetFPS;
    }
}
