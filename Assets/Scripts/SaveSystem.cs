using System.IO;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static string directory = "SaveData";
    public static string fileName = "MySave.txt";

    public static void Save(PlayerData data)
    {
        if (!DirectoryExists())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/" + directory);
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetFullPath());
        bf.Serialize(file, data);
        Debug.Log("Saved Data");

        

        file.Close();
    }
    
    public static PlayerData Load()
    {
        if(SaveExists())
        {
            try
            {
                Debug.Log("Loaded Data");
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(GetFullPath(), FileMode.Open);
                PlayerData data = (PlayerData)bf.Deserialize(file);
                file.Close();



                return data;


            }
            catch (SerializationException)
            {
                Debug.Log("Failed to load file");
            }
        }
        return null;
    }

    private static bool SaveExists()
    {
        return File.Exists(GetFullPath());
    }

    private static bool DirectoryExists()
    {
        return Directory.Exists(Application.persistentDataPath + "/" + directory);
    }

    private static string GetFullPath()
    {
        return Application.persistentDataPath + "/" + directory + "/" + fileName;
    }
}
