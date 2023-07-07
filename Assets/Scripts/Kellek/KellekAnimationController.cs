using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KellekAnimationController : MonoBehaviour
{
    Animator animator; //Animator.

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Transition(bool chase)
    {
        animator.SetBool("Chase", chase);
    }
}
