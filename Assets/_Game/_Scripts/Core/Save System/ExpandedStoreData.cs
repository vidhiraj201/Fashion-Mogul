using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandedStoreData : MonoBehaviour
{
    public HashSet<string> storedStore { get; private set; } = new HashSet<string>();

    public List<GameObject> ExpandedData = new List<GameObject>();
    
    void Start()
    {

        GameEvent.SaveInitiated += Save;
        Load();
    }

    void Save()
    {
        StoreData.Save(storedStore, "StoredStore");
    }

    void Load()
    {
        if (StoreData.saveExist("StoredStore"))
        {
            storedStore = StoreData.Load<HashSet<string>>("StoredStore");
        }
    }
}
