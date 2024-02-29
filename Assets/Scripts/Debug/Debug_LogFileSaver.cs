using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Debug_LogFileSaver : MonoBehaviour
{
    private static string path = Application.persistentDataPath + "/Player.log";

    void OnApplicationQuit(){

        #region Log File Saving
        string recordLogFileName = "Player-Log-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
        File.Copy(path, Application.persistentDataPath + "/" + recordLogFileName , true);
        #endregion

        #region Log File Clearing
        var files = Directory.GetFiles(Application.persistentDataPath, "*.log");
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
