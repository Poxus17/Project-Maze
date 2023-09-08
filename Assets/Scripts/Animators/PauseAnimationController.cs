using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip animationClip;
    [SerializeField] BoolVariable chaseLock;

    public void PlayAnimation()
    {
        if (chaseLock.value)
            return;

        animator.SetTrigger("PlayCountdown");
    }

    // This method will be called when the animation finishes
    public void OnAnimationFinished()
    {
        UIManager.Instance.LaunchUIComponent(1);
    }
}
