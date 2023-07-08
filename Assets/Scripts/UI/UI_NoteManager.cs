using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_NoteManager : MonoBehaviour
{
    [SerializeField] GameObject NoteCanvas;
    [SerializeField] TMPro.TMP_Text NoteText;
    [SerializeField] NoteDataVariable CurrentNote;

    public void ReadNote()
    {
        NoteCanvas.SetActive(true);
        NoteText.text = CurrentNote.value.text;
        MusicMan.instance.PlaySE(CurrentNote.value.clip, 1.0f);
    }

    public void LeaveNote()
    {
        NoteCanvas.SetActive(false);
        MusicMan.instance.StopSE();
    }
}
