using Unity.VisualScripting;
using UnityEngine;

public class PuzzeComponentValueRead : PuzzleComponent
{
    private int currentValue;
    private IIndexRecipient indexRecipient;

    private void Start(){
        indexRecipient = GetComponent<IIndexRecipient>();
    }

    public void ReadValue(){
        try{
            currentValue = puzzleValueTransmitter.Value;
        }
        catch { return; }
        
        indexRecipient.SetIndex(currentValue);
    }
}
