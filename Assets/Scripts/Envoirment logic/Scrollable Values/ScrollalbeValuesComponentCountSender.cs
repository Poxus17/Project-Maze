using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollalbeValuesComponentCountSender : ScrollalbeValuesComponent
{
    private IIndexRecipient indexRecipient;
    private void Start(){
        indexRecipient = GetComponent(typeof(IIndexRecipient)) as IIndexRecipient;
    }

    protected override void ApplyScroll(){
        indexRecipient.SetIndex(Index);
    }
}

public interface IIndexRecipient
{
    void SetIndex(int newIndex);
}
