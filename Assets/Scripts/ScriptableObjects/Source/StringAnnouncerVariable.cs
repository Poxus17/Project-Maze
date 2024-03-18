using UnityEngine;

[CreateAssetMenu(menuName = "Announcer Variables/String Announcer Variable")]
public class StringAnnouncerVariable : StringVariable
{
    public GameEvent announceEvent;

    public void AnnounceSet(string newValue)
    {
        value = newValue;
        announceEvent.Raise();
    }

    public void AnnounceDefault() => AnnounceSet(defaultValue);

    public void QuiteSet(string newValue) => value = newValue;

    public void RaiseEvent() {announceEvent.Raise();}
}
