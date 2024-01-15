using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    public float value;

    public void SetValue(float value)
    {
        this.value = value;
    }
}
