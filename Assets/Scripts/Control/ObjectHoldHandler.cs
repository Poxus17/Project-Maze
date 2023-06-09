using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHoldHandler : MonoBehaviour
{
    [SerializeField] BoolVariable interactionAllowed;
    [SerializeField] GameobjectVariable heldObject;
    [SerializeField] Transform holdBase;
    [SerializeField] float releaseDelay;

    bool isHeld = false;

    private delegate void CallRelease();
    private event CallRelease OnCallRelease;

    public void EnterHoldState()
    {
        interactionAllowed.value = false;
        heldObject.value.transform.SetParent(holdBase);
        heldObject.value.transform.localPosition = Vector3.zero;
        OnCallRelease += heldObject.value.GetComponent<ObjectHoldComponent>().LetMeGo;
    }

    public void ReleaseHoldState()
    {
        OnCallRelease();
        OnCallRelease -= heldObject.value.GetComponent<ObjectHoldComponent>().LetMeGo;
        interactionAllowed.value = true;
    }
}
