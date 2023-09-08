using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class SelfConsumingCollisionTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent triggerEvent;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            triggerEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
