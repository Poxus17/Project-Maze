using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_LogAgent : MonoBehaviour
{
    [SerializeField] string logMessage;

    public void LogMessage()
    {
        Debug.Log(logMessage);
    }

    public void LogMessage(string message)
    {
        Debug.Log(message);
    }

    public void LogAsWarning()
    {
        Debug.LogWarning(logMessage);
    }

    public void LogAsWarning(string message)
    {
        Debug.LogWarning(message);
    }

    public void LogAsError()
    {
        Debug.LogError(logMessage);
    }

    public void LogAsError(string message)
    {
        Debug.LogError(message);
    }
}
