using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPastObjectData", menuName = "ScriptableObjects/Past object data", order = 1)]
public class PastObjectData : ScriptableObject
{
    public AudioClip clip;
    public string transcript;
}
