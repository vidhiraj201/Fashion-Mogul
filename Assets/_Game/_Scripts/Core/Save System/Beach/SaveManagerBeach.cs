using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManagerBeach 
{
    public static void Save(GameDataBeach data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static GameDataBeach Load()
    {
        if (!File.Exists(GetPath()))
        {
            GameDataBeach emptyData = new GameDataBeach();
            Save(emptyData);
            return emptyData;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Open);
        GameDataBeach data = formatter.Deserialize(fs) as GameDataBeach;
        fs.Close();

        return data;
    }

    private static string GetPath()
    {
        return Application.persistentDataPath + "/dataBeachSection.txt";
    }
}
