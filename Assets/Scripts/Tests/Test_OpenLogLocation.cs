using System.Diagnostics;
using System.IO;
using UnityEngine;

public class Test_OpenLogLocation : MonoBehaviour
{
    public void OpenLogLocation()
    {
        if (Directory.Exists(Application.persistentDataPath))
        {
            Process.Start("explorer", Application.persistentDataPath.Replace(@"/", @"\"));
        }
    }
}
