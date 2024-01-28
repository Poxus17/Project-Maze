using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Announcer Variables/Float Announcer Variable")]
public class FloatAnnouncerVariable : FloatVariable
{
    public GameEvent announceEvent;

    public void AnnounceSet(float newValue)
    {
        value = newValue;
        announceEvent.Raise();
    }
}
