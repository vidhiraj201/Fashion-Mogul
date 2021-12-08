using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;

public class SavingAndLoadingCasual : MonoBehaviour
{
    public Stores Rack0;
    public Stores Rack1;
    public Stores Rack2;
    public Stores Rack3;

    public GameDataCasual GDS;

    private void Awake()
    {
        LoadGame();
        GDS = SaveManagerCasual.Load();
    }


    private void Update()
    {
        if(GDS.unlock1 && !Rack0.unlock)
        {
            Rack0.unlock = GDS.unlock1;
        }
        if(GDS.unlock2 && !Rack1.unlock)
        {
            Rack1.unlock = GDS.unlock2;
        }
        if(GDS.unlock3 && !Rack2.unlock)
        {
            Rack2.unlock = GDS.unlock3;
        }
        if(GDS.unlock4 && !Rack3.unlock)
        {
            Rack3.unlock = GDS.unlock4;
        }
    }


    public void SaveGame()
    {
        GDS.unlock1 = Rack0.unlock;
        GDS.unlock2 = Rack1.unlock;
        GDS.unlock3 = Rack2.unlock;
        GDS.unlock4 = Rack3.unlock;
        SaveManagerCasual.Save(GDS);
        print("Racks Saved");
    }

    public void LoadGame()
    {
        Rack0.unlock = GDS.unlock1;
        Rack1.unlock = GDS.unlock2;
        Rack2.unlock = GDS.unlock3;
        Rack3.unlock = GDS.unlock4;
        
    }

}
