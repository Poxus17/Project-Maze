using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float Variable")]
public class FloatVariable : ScriptableObject
{
    public float value;

    public void SetValue(float value)
    {
        this.value = value;
    }
}
