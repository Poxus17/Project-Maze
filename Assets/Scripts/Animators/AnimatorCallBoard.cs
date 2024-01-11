using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorCallBoard : MonoBehaviour
{
    Animator animator; // Animator.

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetBool(string name, bool value)
    {
        animator.SetBool(name, value);
    }

    public void SetTrigger(string name)
    {
        animator.SetTrigger(name);
    }

    public void SetFloat(string name, float value)
    {
        animator.SetFloat(name, value);
    }

    public void SetInt(string name, int value)
    {
        animator.SetInteger(name, value);
    }
}
