using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_MainMenuCameraEffect : MonoBehaviour
{
    int mod = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Breath");
    }

    IEnumerator Breath()
    {
        while (true)
        {
            for (int i = 0; i < 1500; i++)
            {
                transform.position += Vector3.up * 0.2f * Time.deltaTime * mod;
                yield return null;
            }
            mod *= -1;
        }
    }
}
