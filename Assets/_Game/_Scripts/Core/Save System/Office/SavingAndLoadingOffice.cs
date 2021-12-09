using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;

public class SavingAndLoadingOffice : MonoBehaviour
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

    public GameDataOffice GDO;

    private void Awake()
    {
        empCountData();
        LoadGame();
        GDO = SaveManagerOffice.Load();
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
        if (GDO.unlock1 && !Rack0.unlock)
        {
            Rack0.unlock = GDO.unlock1;
        }
        if (GDO.unlock2 && !Rack1.unlock)
        {
            Rack1.unlock = GDO.unlock2;
        }
        if (GDO.unlock3 && !Rack2.unlock)
        {
            Rack2.unlock = GDO.unlock3;
        }
        if (GDO.unlock4 && !Rack3.unlock)
        {
            Rack3.unlock = GDO.unlock4;
        }
    }

    void Slots()
    {
        if (S1.gameObject.activeSelf && GDO.S1 && !S1.open)
        {
            S1.open = GDO.S1;
        }
        if (S2.gameObject.activeSelf && GDO.S2 && !S2.open)
        {
            S2.open = GDO.S2;
        }
        if (S3.gameObject.activeSelf && GDO.S3 && !S3.open)
        {
            S3.open = GDO.S3;
        }
        if (S4.gameObject.activeSelf && GDO.S4 && !S4.open)
        {
            S4.open = GDO.S4;
        }
    }

    void empCountData()
    {
        if (empC.EmployeeCountData < GDO.empCount)
            empC.EmployeeCountData += 1;
    }

    public void SaveGame()
    {
        if (!S1.gameObject.activeSelf)
            GDO.S1 = true;

        if (!S2.gameObject.activeSelf)
            GDO.S2 = true;

        if (!S3.gameObject.activeSelf)
            GDO.S3 = true;

        if (!S4.gameObject.activeSelf)
            GDO.S4 = true;

        GDO.unlock1 = Rack0.unlock;
        GDO.unlock2 = Rack1.unlock;
        GDO.unlock3 = Rack2.unlock;
        GDO.unlock4 = Rack3.unlock;


        SaveManagerOffice.Save(GDO);
        print("Racks Saved");
    }

    public void LoadGame()
    {
        Rack0.unlock = GDO.unlock1;
        Rack1.unlock = GDO.unlock2;
        Rack2.unlock = GDO.unlock3;
        Rack3.unlock = GDO.unlock4;

        if (S1.gameObject.activeSelf)
            S1.open = GDO.S1;

        if (S2.gameObject.activeSelf)
            S2.open = GDO.S2;

        if (S3.gameObject.activeSelf)
            S3.open = GDO.S3;

        if (S4.gameObject.activeSelf)
            S4.open = GDO.S4;

    }
}
