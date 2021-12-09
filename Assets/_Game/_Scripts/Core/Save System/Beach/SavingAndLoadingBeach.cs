using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;
public class SavingAndLoadingBeach : MonoBehaviour
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

    public GameDataBeach GDB;

    private void Awake()
    {
        empCountData();
        LoadGame();
        GDB = SaveManagerBeach.Load();
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
        if (GDB.unlock1 && !Rack0.unlock)
        {
            Rack0.unlock = GDB.unlock1;
        }
        if (GDB.unlock2 && !Rack1.unlock)
        {
            Rack1.unlock = GDB.unlock2;
        }
        if (GDB.unlock3 && !Rack2.unlock)
        {
            Rack2.unlock = GDB.unlock3;
        }
        if (GDB.unlock4 && !Rack3.unlock)
        {
            Rack3.unlock = GDB.unlock4;
        }
    }

    void Slots()
    {
        if (S1.gameObject.activeSelf && GDB.S1 && !S1.open)
        {
            S1.open = GDB.S1;
        }
        if (S2.gameObject.activeSelf && GDB.S2 && !S2.open)
        {
            S2.open = GDB.S2;
        }
        if (S3.gameObject.activeSelf && GDB.S3 && !S3.open)
        {
            S3.open = GDB.S3;
        }
        if (S4.gameObject.activeSelf && GDB.S4 && !S4.open)
        {
            S4.open = GDB.S4;
        }
    }

    void empCountData()
    {
        if (empC.EmployeeCountData < GDB.empCount)
            empC.EmployeeCountData += 1;
    }

    public void SaveGame()
    {
        if (!S1.gameObject.activeSelf)
            GDB.S1 = true;

        if (!S2.gameObject.activeSelf)
            GDB.S2 = true;

        if (!S3.gameObject.activeSelf)
            GDB.S3 = true;

        if (!S4.gameObject.activeSelf)
            GDB.S4 = true;

        GDB.unlock1 = Rack0.unlock;
        GDB.unlock2 = Rack1.unlock;
        GDB.unlock3 = Rack2.unlock;
        GDB.unlock4 = Rack3.unlock;


        SaveManagerBeach.Save(GDB);
        print("Racks Saved");
    }

    public void LoadGame()
    {
        Rack0.unlock = GDB.unlock1;
        Rack1.unlock = GDB.unlock2;
        Rack2.unlock = GDB.unlock3;
        Rack3.unlock = GDB.unlock4;

        if (S1.gameObject.activeSelf)
            S1.open = GDB.S1;

        if (S2.gameObject.activeSelf)
            S2.open = GDB.S2;

        if (S3.gameObject.activeSelf)
            S3.open = GDB.S3;

        if (S4.gameObject.activeSelf)
            S4.open = GDB.S4;

    }
}
