using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManagerSection 
{
    public static void Save(GameDataSection data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();        
    }

    public static GameDataSection Load()
    {
        if (!File.Exists(GetPath()))
        {
            GameDataSection emptyData = new GameDataSection();
            Save(emptyData);
            return emptyData;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Open);
        GameDataSection data = formatter.Deserialize(fs) as GameDataSection;
        fs.Close();

        return data;


    }

    private static string GetPath()
    {
        return Application.persistentDataPath + "/dataStations.txt";
    }
}
