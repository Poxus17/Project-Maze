using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InventoryAnimatorHandler : MonoBehaviour
{ 
    Animator animator; //Animator.

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayUI()
    {
        animator.SetTrigger("Play");
    }

    public void GoBack()
    {
        animator.SetTrigger("Revert");
    }
}
