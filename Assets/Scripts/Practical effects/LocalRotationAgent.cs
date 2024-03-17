using UnityEngine;

public class LocalRotationAgent : MonoBehaviour
{
    [SerializeField] Vector3 eulerRotation;
    private Quaternion initialRotation;

    private void Awake(){
        initialRotation = transform.localRotation;
    }

    public void SetRotation(){
        transform.localRotation = Quaternion.Euler(eulerRotation);
    }

    public void ResetRotation(){
        transform.localRotation = initialRotation;
    }

}
