using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteComponent : MonoBehaviour
{
    [SerializeField] NoteDataVariable noteData;

    public void OpenNote()
    {
        NoteManager.instance.OpenNote(noteData.value);
    }
}
