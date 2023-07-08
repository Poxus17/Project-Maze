using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] GameEvent openNoteEvent;
    [SerializeField] NoteDataVariable currentNoteData;

    public static NoteManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void OpenNote(NoteData note)
    {
        currentNoteData.value = note;
        openNoteEvent.Raise();
    }
}
