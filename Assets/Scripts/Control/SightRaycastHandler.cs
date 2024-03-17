using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SightRaycastHandler : MonoBehaviour
{
    [SerializeField] string targetTag;
    
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag(targetTag)){
            var detectable = other.GetComponent<IDetectable>();

            if(detectable != null)
                detectable.OnDetect(true);
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag(targetTag)){
            var detectable = other.GetComponent<IDetectable>();

            if(detectable != null)
                detectable.OnDetect(false);
        }
    }
}
