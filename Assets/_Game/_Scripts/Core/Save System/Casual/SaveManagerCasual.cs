using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManagerCasual 
{
    public static void Save(GameDataCasual data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static GameDataCasual Load()
    {
        if (!File.Exists(GetPath()))
        {
            GameDataCasual emptyData = new GameDataCasual();
            Save(emptyData);
            return emptyData;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Open);
        GameDataCasual data = formatter.Deserialize(fs) as GameDataCasual;
        fs.Close();

        return data;


    }

    private static string GetPath()
    {
        return Application.persistentDataPath + "/dataCasualSection.txt";
    }
}
