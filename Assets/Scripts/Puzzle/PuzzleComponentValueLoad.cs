using UnityEngine;

public class PuzzleComponentValueLoad : PuzzleComponent
{
    [SerializeField] int puzzleValue;

    public void LoadValue()
    {
        puzzleValueTransmitter.SetValue(puzzleValue);
    }


}
