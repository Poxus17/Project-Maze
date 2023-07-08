using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NoteDataVariable : ScriptableObject
{
    public NoteData value;
}

[System.Serializable]
public class NoteData 
{
    public string owner;
    [TextArea(15, 20)]
    public string text;
    public AudioClip clip;
}

