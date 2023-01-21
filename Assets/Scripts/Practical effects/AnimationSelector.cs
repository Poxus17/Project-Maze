using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationSelector : MonoBehaviour
{
    [SerializeField] int animationIndex;
    [SerializeField] string paramName;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetInteger(paramName, animationIndex);
    }
}
