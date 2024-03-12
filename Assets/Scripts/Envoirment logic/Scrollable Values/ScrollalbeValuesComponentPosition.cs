using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollalbeValuesComponentPosition : ScrollalbeValuesComponent
{
    [SerializeField] Vector3[] positions;
    [SerializeField] Transform childTarget;
    [SerializeField] bool transition = false;
    [SerializeField] float transitionSpeed = 1f;

    private Transform applyTransform;

    private void Start(){
        applyTransform = childTarget != null ? childTarget : transform;
    }

    protected override void ApplyScroll(){
        if(transition)
            StartCoroutine(Transition(positions[Index]));
        else
            applyTransform.localPosition = positions[Index];
    }

    IEnumerator Transition(Vector3 target){
        var alpha = 0f;

        var initialPos = applyTransform.localPosition;

        while(alpha < 1f){
            alpha += Time.deltaTime * transitionSpeed;
            applyTransform.localPosition = Vector3.Lerp(initialPos, target, alpha);
            yield return null;
        }
    }
}
