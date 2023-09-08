using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_NoteManager : UIComponent
{
    [SerializeField] TMPro.TMP_Text NoteText;
    [SerializeField] NoteDataVariable CurrentNote;

    public override void PersonalEventBindings()
    {
        LaunchComponentPersonalEvents += ReadNote;
        CloseComponentPersonalEvents += LeaveNote;
    }

    public void ReadNote()
    {
        NoteText.text = CurrentNote.value.text;
        MusicMan.instance.PlaySE(CurrentNote.value.clip, 1.0f);
    }

    public void LeaveNote()
    {
        MusicMan.instance.StopSE();
        MusicMan.instance.PlaySE(CurrentNote.value.exitClip, 1.0f);
    }
}
