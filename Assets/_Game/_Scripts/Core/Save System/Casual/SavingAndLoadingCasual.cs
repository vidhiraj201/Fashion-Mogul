using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;

public class SavingAndLoadingCasual : MonoBehaviour
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

    public GameDataCasual GDC;

    private void Awake()
    {
        empCountData();
        LoadGame();
        GDC = SaveManagerCasual.Load();
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
        if (GDC.unlock1 && !Rack0.unlock)
        {
            Rack0.unlock = GDC.unlock1;
        }
        if (GDC.unlock2 && !Rack1.unlock)
        {
            Rack1.unlock = GDC.unlock2;
        }
        if (GDC.unlock3 && !Rack2.unlock)
        {
            Rack2.unlock = GDC.unlock3;
        }
        if (GDC.unlock4 && !Rack3.unlock)
        {
            Rack3.unlock = GDC.unlock4;
        }
    }

    void Slots()
    {
        if(S1.gameObject.activeSelf && GDC.S1 && !S1.open)
        {
            S1.open = GDC.S1;
        }
        if (S2.gameObject.activeSelf && GDC.S2 && !S2.open)
        {
            S2.open = GDC.S2;
        }
        if (S3.gameObject.activeSelf && GDC.S3 && !S3.open)
        {
            S3.open = GDC.S3;
        }
        if (S4.gameObject.activeSelf && GDC.S4 && !S4.open)
        {
            S4.open = GDC.S4;
        }
    }

    void empCountData()
    {
        if (empC.EmployeeCountData < GDC.empCount)
            empC.EmployeeCountData += 1;
    }

    public void SaveGame()
    {
        if(!S1.gameObject.activeSelf && S1.MaxCoinNeedToUnlock<=0)
            GDC.S1 = true;

        if(!S2.gameObject.activeSelf && S2.MaxCoinNeedToUnlock <= 0)
            GDC.S2 = true;

        if(!S3.gameObject.activeSelf && S3.MaxCoinNeedToUnlock <= 0)
            GDC.S3 = true;

        if(!S4.gameObject.activeSelf && S4.MaxCoinNeedToUnlock <= 0 )
            GDC.S4 = true;

        GDC.unlock1 = Rack0.unlock;
        GDC.unlock2 = Rack1.unlock;
        GDC.unlock3 = Rack2.unlock;
        GDC.unlock4 = Rack3.unlock;


        SaveManagerCasual.Save(GDC);
        print("Casual Saved");
    }

    public void LoadGame()
    {
        Rack0.unlock = GDC.unlock1;
        Rack1.unlock = GDC.unlock2;
        Rack2.unlock = GDC.unlock3;
        Rack3.unlock = GDC.unlock4;

        if (S1.gameObject.activeSelf)
            S1.open = GDC.S1;

        if (S2.gameObject.activeSelf)
            S2.open = GDC.S2;

        if (S3.gameObject.activeSelf)
            S3.open = GDC.S3;

        if (S4.gameObject.activeSelf)
            S4.open = GDC.S4;

    }

}
