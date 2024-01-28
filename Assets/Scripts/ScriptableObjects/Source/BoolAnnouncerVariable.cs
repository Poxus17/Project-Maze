using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Announcer Variables/Bool Announcer Variable")]
public class BoolAnnouncerVariable : BoolVariable
{
    public GameEvent announceEvent;

    public void AnnounceSet(bool newValue)
    {
        value = newValue;
        announceEvent.Raise();
    }

    public void RaiseEvent() {announceEvent.Raise();}
}
