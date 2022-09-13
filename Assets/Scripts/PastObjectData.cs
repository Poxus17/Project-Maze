using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewPastObjectData", menuName = "ScriptableObjects/Past object data", order = 1)]
public class PastObjectData : ScriptableObject
{
    public AudioClip clip;
    [TextArea(15, 20)]
    public string transcript;
}
