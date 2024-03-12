using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Debug_LogFileSaver : MonoBehaviour
{
    private static string path;
    private static string persistentDataPath;

    private void OnEnable()
    {
        path = Application.persistentDataPath + "/Player.log";
        persistentDataPath = Application.persistentDataPath;
    }

    void OnApplicationQuit(){

        #region Log File Saving
        string recordLogFileName = "Player-Log-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
        File.Copy(path, persistentDataPath + "/" + recordLogFileName , true);
        #endregion

        #region Log File Clearing
        var files = Directory.GetFiles(persistentDataPath, "*.log");
        var logFiles = Array.FindAll(files, x => x.Contains("Player-Log-"));

        foreach (var logFilePath in logFiles)
        {
            var createTime = File.GetCreationTime(logFilePath);
            if (createTime < DateTime.Now.AddDays(-3))
            {
                File.Delete(logFilePath);
            }
        }
        #endregion  
    }
}
