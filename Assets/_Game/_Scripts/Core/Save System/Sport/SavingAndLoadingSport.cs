using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;

public class SavingAndLoadingSport : MonoBehaviour
{
    public EmployeeCounting empC;

    public Stores Rack0;
    public Stores Rack1;
    public Stores Rack2;
    public Stores Rack3;

    public Station S1;
    public Station S2;
    public Station S3;
    public Station S4;

    public GameDataSport GDS;

    private void Awake()
    {
        empCountData();
        LoadGame();
        GDS = SaveManagerSport.Load();
    }


    private void Update()
    {
        Racks();
        Slots();
        empCountData();

        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveGame();
        }
    }
    void Racks()
    {
        if (GDS.unlock1 && !Rack0.unlock)
        {
            Rack0.unlock = GDS.unlock1;
        }
        if (GDS.unlock2 && !Rack1.unlock)
        {
            Rack1.unlock = GDS.unlock2;
        }
        if (GDS.unlock3 && !Rack2.unlock)
        {
            Rack2.unlock = GDS.unlock3;
        }
        if (GDS.unlock4 && !Rack3.unlock)
        {
            Rack3.unlock = GDS.unlock4;
        }
    }

    void Slots()
    {
        if (S1.gameObject.activeSelf && GDS.S1 && !S1.open)
        {
            S1.open = GDS.S1;
        }
        if (S2.gameObject.activeSelf && GDS.S2 && !S2.open)
        {
            S2.open = GDS.S2;
        }
        if (S3.gameObject.activeSelf && GDS.S3 && !S3.open)
        {
            S3.open = GDS.S3;
        }
        if (S4.gameObject.activeSelf && GDS.S4 && !S4.open)
        {
            S4.open = GDS.S4;
        }
    }

    void empCountData()
    {
        if (empC.EmployeeCountData < GDS.empCount)
            empC.EmployeeCountData += 1;
    }

    public void SaveGame()
    {
        if (!S1.gameObject.activeSelf)
            GDS.S1 = true;

        if (!S2.gameObject.activeSelf)
            GDS.S2 = true;

        if (!S3.gameObject.activeSelf)
            GDS.S3 = true;

        if (!S4.gameObject.activeSelf)
            GDS.S4 = true;

        GDS.unlock1 = Rack0.unlock;
        GDS.unlock2 = Rack1.unlock;
        GDS.unlock3 = Rack2.unlock;
        GDS.unlock4 = Rack3.unlock;


        SaveManagerSport.Save(GDS);
        print("Racks Saved");
    }

    public void LoadGame()
    {
        Rack0.unlock = GDS.unlock1;
        Rack1.unlock = GDS.unlock2;
        Rack2.unlock = GDS.unlock3;
        Rack3.unlock = GDS.unlock4;

        if (S1.gameObject.activeSelf)
            S1.open = GDS.S1;

        if (S2.gameObject.activeSelf)
            S2.open = GDS.S2;

        if (S3.gameObject.activeSelf)
            S3.open = GDS.S3;

        if (S4.gameObject.activeSelf)
            S4.open = GDS.S4;

    }
}
