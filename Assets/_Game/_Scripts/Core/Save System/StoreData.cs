using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


public class StoreData : MonoBehaviour
{
    public static void Save<T>(T objectToSave, string key)
    {
        string path = Application.dataPath + "/_Game/saves/";
        Directory.CreateDirectory(path);

        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream fileStream = new FileStream(path+key+".txt",FileMode.Create))
        {
            formatter.Serialize(fileStream, objectToSave);
        }

    }
    public static T  Load<T>(string key)
    {
        string path = Application.dataPath + "/_Game/saves/";

        BinaryFormatter formatter = new BinaryFormatter();
        T returnValue = default(T);


        using (FileStream fileStream = new FileStream(path + key + ".txt", FileMode.Open))
        {
            returnValue =  (T)formatter.Deserialize(fileStream);
        }

        return returnValue;
    }

    public static bool saveExist(string key)
    {
        string path = Application.dataPath + "/_Game/saves/" + key+".txt";
        return File.Exists(path);
    }

    public static void DltAFile()
    {
        string path = Application.dataPath + "/_Game/saves/";
        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete();
        Directory.CreateDirectory(path);
    }

}
