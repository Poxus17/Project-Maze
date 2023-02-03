using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StartAnimatorWithDelay : MonoBehaviour
{
    Animator animator;
    [SerializeField] float minDelay = 1f;
    [SerializeField] float maxDelay = 5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        float delay = Random.Range(minDelay, maxDelay);
        Invoke("StartAnimator", delay);
    }

    private void StartAnimator()
    {
        animator.enabled = true;
    }
}
