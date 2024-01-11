using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class SelfConsumingCollisionTrigger : IndexedConsumable
{

    [SerializeField] UnityEvent triggerEvent;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            triggerEvent.Invoke();
            RegisterAsConsumed();
            Destroy(gameObject);
        }
    }
}
