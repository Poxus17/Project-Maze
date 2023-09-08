using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolAnnouncerVariable : BoolVariable
{
    public GameEvent announceEvent;

    public void AnnounceSet(bool newValue)
    {
        value = newValue;
        announceEvent.Raise();
    }
}
