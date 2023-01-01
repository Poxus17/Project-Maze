using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip animationClip;
    [SerializeField] GameEvent enterPause;

    public void PlayAnimation()
    {
        animator.SetTrigger("PlayCountdown");
    }

    // This method will be called when the animation finishes
    public void OnAnimationFinished()
    {
        enterPause.Raise();
    }
}
