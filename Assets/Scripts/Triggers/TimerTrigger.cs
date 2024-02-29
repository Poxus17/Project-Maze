using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimerTrigger : BaseTrigger
{
    [SerializeField] float timerTime;

    private bool runningTimer;

    public override void SetActive(bool active)
    {
        base.SetActive(active);

        if(runningTimer || !active)
            return;

        GlobalTimerManager.instance.RegisterForTimer(Trigger, timerTime);
        runningTimer = true;
    }

}
