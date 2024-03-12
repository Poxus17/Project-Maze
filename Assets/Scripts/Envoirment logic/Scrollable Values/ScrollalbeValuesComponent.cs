using UnityEngine;

[RequireComponent(typeof(ScrollableValuesIndex))]
public class ScrollalbeValuesComponent : MonoBehaviour
{
    private ScrollableValuesIndex scrollableValuesIndex;
    protected int Index => scrollableValuesIndex.ScrollIndex;
    protected void Awake(){
        scrollableValuesIndex = GetComponent<ScrollableValuesIndex>();
        scrollableValuesIndex.ApplyScroll += ApplyScroll;
    }

    protected virtual void ApplyScroll(){
        Debug.LogError("ApplyScroll was not overriden in " + this.name);
    }

}
