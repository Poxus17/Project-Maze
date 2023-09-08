using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class ProfilerLogger : MonoBehaviour
{
    string baseLogName = "performanceLog";
    // Start is called before the first frame update
    void Start()
    {
        Profiler.logFile = baseLogName; //Also supports passing "myLog.raw"
        Profiler.enableBinaryLog = true;
        Profiler.enabled = true;
    }

    public void SnapProfile(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.started)
            Profiler.logFile = baseLogName + "_" + System.DateTime.Now.Date.Month.ToString() + System.DateTime.Now.Date.Day.ToString() + "_" + System.DateTime.Now.TimeOfDay.Hours.ToString() + System.DateTime.Now.TimeOfDay.Minutes.ToString()+ System.DateTime.Now.TimeOfDay.Seconds.ToString();
    }
}
