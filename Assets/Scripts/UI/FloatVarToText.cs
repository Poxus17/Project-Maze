using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatVarToText : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] FloatVariable var;

    // Update is called once per frame
    void Update()
    {
        text.text = var.value.ToString();
    }
}
