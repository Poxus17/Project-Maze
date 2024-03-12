using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "\"Special\" Variables/Note Data Variable")]
public class NoteDataVariable : StoreableItem
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
    public AudioClip exitClip;
}

