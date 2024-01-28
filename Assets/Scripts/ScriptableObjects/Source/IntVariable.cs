using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int Variable")]
public class IntVariable : ScriptableObject
{
    public int value;

    public void SetValue(int value)
    {
        this.value = value;
    }
}