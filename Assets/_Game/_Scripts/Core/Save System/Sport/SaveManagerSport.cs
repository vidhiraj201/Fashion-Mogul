using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManagerSport
{
    public static void Save(GameDataSport data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static GameDataSport Load()
    {
        if (!File.Exists(GetPath()))
        {
            GameDataSport emptyData = new GameDataSport();
            Save(emptyData);
            return emptyData;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Open);
        GameDataSport data = formatter.Deserialize(fs) as GameDataSport;
        fs.Close();

        return data;


    }

    private static string GetPath()
    {
        return Application.persistentDataPath + "/dataSportSection.txt";
    }
}
