using UnityEngine;
using UnityEngine.Events;

public class ObjectDistanceTrigger : MonoBehaviour
{
    [SerializeField] GameObject targetObject; // The object to check against
    [SerializeField] float triggerDistance; // The distance to trigger at
    [SerializeField] bool selfConsume; // Whether or not to self consume after triggering
    [SerializeField] UnityEvent triggerEvent; // The event to trigger

    void Update(){
        if(Vector3.Distance(transform.position, targetObject.transform.position) < triggerDistance){
            triggerEvent.Invoke();

            if(selfConsume){
                gameObject.SetActive(false);
            }
        }
    }
}
