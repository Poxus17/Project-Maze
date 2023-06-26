using UnityEditor;
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ObjectHoldComponent : MonoBehaviour
{
    [SerializeField] GameobjectVariable heldObject;
    [SerializeField] GameEvent callForHold;
    [SerializeField] Rigidbody rigidbody; // rigidbody.
    [SerializeField] FloatVariable releaseDelay;
    [SerializeField] FloatVariable throwPower;

    private void Awake()
    {
#if UNITY_EDITOR
        heldObject = (GameobjectVariable)AssetDatabase.LoadAssetAtPath("Assets/Scripts/ScriptableObjects/Instances/Vars/HeldObject.asset", typeof(GameobjectVariable));
        callForHold = (GameEvent)AssetDatabase.LoadAssetAtPath("Assets/Scripts/ScriptableObjects/Instances/Events/CallHoldObject.asset", typeof(GameEvent));
        rigidbody = GetComponent<Rigidbody>();
        releaseDelay = (FloatVariable)AssetDatabase.LoadAssetAtPath("Assets/Scripts/ScriptableObjects/Instances/Vars/Floats/HeldObject_ReleaseDelay.asset", typeof(FloatVariable));
        throwPower = (FloatVariable)AssetDatabase.LoadAssetAtPath("Assets/Scripts/ScriptableObjects/Instances/Vars/Floats/HeldObject_ThrowPower.asset", typeof(FloatVariable));
#endif
    }

    public void HoldMe()
    {
        heldObject.value = gameObject;
        callForHold.Raise();
        rigidbody.isKinematic = true;
    }

    public void LetMeGo()
    {
        StartCoroutine(OnRelease());
    }

    IEnumerator OnRelease()
    {
        var throwPosition0 = transform.position;

        yield return new WaitForSeconds(releaseDelay.value);

        transform.parent = null;
        heldObject.value = null;
        rigidbody.isKinematic = false;

        var throwVector = transform.position - throwPosition0;
        Debug.Log(throwVector);
        rigidbody.velocity = throwVector * throwPower.value;
    }

}
