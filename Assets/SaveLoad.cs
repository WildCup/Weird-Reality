using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{
    static string path = "C:/Users/hagel/Documents/Unity/Weird Reality/Assets/PlayerProgress.txt";
    public static void Save(PlayerStats p)
    {
        //BinaryFormatter formatter = new BinaryFormatter();
        //string path = Application.persistentDataPath + "/PlayerProgress.afowqneof";
        //FileStream stream = new FileStream(path,FileMode.Create);
        //formatter.Serialize(stream, data);

        PlayerData data = new PlayerData(p);

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }
    public static PlayerData Load()
    {
        PlayerData data;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.Log("PlayerProgress did not found");
            data = new PlayerData(PlayerStats.instance);
        }
            return data;
    }
    public static void DeleteProgress()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
