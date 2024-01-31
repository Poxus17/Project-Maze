using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/player.cannon";
    private static string absoluteDataPath = Application.persistentDataPath + "/data.absolute";

    public static void SavePlayer(PlayerSaveData playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, playerData);

        Debug.Log("Saved to " + path);

        stream.Close();
    }

    public static void SaveAbsoluteData(AbsoluteData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(absoluteDataPath, FileMode.Create);

        formatter.Serialize(stream, data);

        Debug.Log("Saved to " + absoluteDataPath);

        stream.Close();
    }


    public static PlayerSaveData LoadPlayer()
    {
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream playerStream = new FileStream(path, FileMode.Open);
            PlayerSaveData playerData = formatter.Deserialize(playerStream) as PlayerSaveData;
            playerStream.Close();

            return playerData;
        }
        else
        {
            Debug.LogError("Save file not found.\n" +
                "Game save intended path: " + path + "\n" +
                "Please ensure the path variable is set correctly, and that save files are being properly generated \n" +
                "Error - SaveSystem.cs, line 23");

            return null;
        }
    }

    public static AbsoluteData LoadAbsoluteData(){
        if(File.Exists(absoluteDataPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream absoluteStream = new FileStream(absoluteDataPath, FileMode.Open);
            AbsoluteData absoluteData;
            try{
                absoluteData = formatter.Deserialize(absoluteStream) as AbsoluteData;
            }
            catch(System.Exception e){
                Debug.LogError("Error message: " + e.Message);
                absoluteStream.Close();
                return null;
            }
            
            absoluteStream.Close();
            return absoluteData;
        }
        else
        {
            Debug.LogError("Save file not found.\n" +
                "Game save intended path: " + absoluteDataPath + "\n" +
                "Please ensure the path variable is set correctly, and that save files are being properly generated \n" +
                "Error - SaveSystem.cs, line 23");

            return null;
        }
    }

    public static void DeleteSaveFile()
    {
        //Check if save file exists
        if (!File.Exists(path))
            return;

        File.Delete(path);
        Debug.Log("Save file deleted");
    }


}

public class LoadDataCollection{
    private PlayerSaveData _playerData;
    private AbsoluteData _absoluteData;

    public PlayerSaveData PlayerData => _playerData;
    public AbsoluteData AbsoluteData => _absoluteData;

    public LoadDataCollection(PlayerSaveData playerData, AbsoluteData absoluteData){
        this._playerData = playerData;
        this._absoluteData = absoluteData;
    }
}
