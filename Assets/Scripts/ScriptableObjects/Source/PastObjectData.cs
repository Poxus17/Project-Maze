using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewPastObjectData", menuName = "ScriptableObjects/Past object data", order = 1)]
public class PastObjectData : ScriptableObject
{
    public string name;

    public Sprite icon;

    public AudioClip clip;

    public GameObject itemPrefab;

    [TextArea(15, 20)]
    public string transcript;

    public void Copy(PastObjectData pod)
    {
        name = pod.name;
        icon = pod.icon;
        clip = pod.clip;
        itemPrefab = pod.itemPrefab;
        transcript = pod.transcript;
    }
}
