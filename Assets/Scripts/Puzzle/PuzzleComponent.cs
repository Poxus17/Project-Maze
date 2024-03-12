
using UnityEngine;
using UnityEngine.Events;

public class PuzzleComponent : MonoBehaviour
{
    protected ValueTransmitter<int> puzzleValueTransmitter;
    public void Init(ValueTransmitter<int> valueTransmitter)
    {
        puzzleValueTransmitter = valueTransmitter;
    }

    public void ClearValue()
    {
        puzzleValueTransmitter.ClearValue();
    }
}

public class IntEvent : UnityEvent<int> { }
