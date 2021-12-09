using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveManagerOffice 
{
    public static void Save(GameDataOffice data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static GameDataOffice Load()
    {
        if (!File.Exists(GetPath()))
        {
            GameDataOffice emptyData = new GameDataOffice();
            Save(emptyData);
            return emptyData;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Open);
        GameDataOffice data = formatter.Deserialize(fs) as GameDataOffice;
        fs.Close();

        return data;


    }

    private static string GetPath()
    {
        return Application.persistentDataPath + "/dataOfficeSection.txt";
    }
}
