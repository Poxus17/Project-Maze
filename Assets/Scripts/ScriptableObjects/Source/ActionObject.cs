using UnityEngine;

[CreateAssetMenu(fileName = "NewActionObjectData", menuName = "\"Special\" Variables/Action object data")]
public class ActionObject : PhysicalObject
{
    public GameEvent action;

    public void Copy(ActionObject other)
    {
        base.Copy(other);
        itemPrefab = other.itemPrefab;
        action = other.action;
    }
}
