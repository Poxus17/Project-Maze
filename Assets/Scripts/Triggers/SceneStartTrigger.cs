using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartTrigger : MonoBehaviour
{
    [SerializeField] UnityEngine.Events.UnityEvent triggerEvent;

    // Start is called before the first frame update
    void Start()
    {
        triggerEvent.Invoke();
    }
}
