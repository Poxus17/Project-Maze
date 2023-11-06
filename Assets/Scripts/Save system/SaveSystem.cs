using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/player.cannon";

    public static void SavePlayer(GameObject player, bool[] eventsMemory)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerSaveData playerData = new PlayerSaveData(player, eventsMemory);

        formatter.Serialize(stream, playerData);

        stream.Close();
    }

    public static PlayerSaveData LoadPlayer()
    {
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerSaveData playerData = formatter.Deserialize(stream) as PlayerSaveData;

            stream.Close();
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
}
