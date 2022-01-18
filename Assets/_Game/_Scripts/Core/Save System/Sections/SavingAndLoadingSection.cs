using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;

public class SavingAndLoadingSection : MonoBehaviour
{
    public StoreExpansion Store_1;
    public StoreExpansion Store_2;
    public StoreExpansion Store_3;

    public OpenStore OS1;
    public OpenStore OS2;
    public OpenStore OS3;

    public GameDataSection GDS;
    private void Awake()
    {
        //LoadGame();
        GDS = SaveManagerSection.Load();
    }

    private void Update()
    {
        if (Store_1.gameObject.activeSelf && GDS.Section_1 <=0)
            Store_1.MaxCoinNeedToUnlock = 0;

        if (Store_2.gameObject.activeSelf && GDS.Section_2 <= 0)
            Store_2.MaxCoinNeedToUnlock = 0;

        if (Store_3.gameObject.activeSelf && GDS.Section_3 <= 0)
            Store_3.MaxCoinNeedToUnlock = 0;
    }

    public void SaveGames()
    {
        try
        {
            /*if (Store_1.gameObject.activeSelf)*/
            GDS.Section_1 = (int)Store_1.MaxCoinNeedToUnlock;

            /*if (Store_2.gameObject.activeSelf)*/
            GDS.Section_2 = (int)Store_2.MaxCoinNeedToUnlock;

            /*if (Store_3.gameObject.activeSelf)*/
            GDS.Section_3 = (int)Store_3.MaxCoinNeedToUnlock;

            GDS.Section_1_Cam = OS1.isOpen;
            GDS.Section_2_Cam = OS2.isOpen;
            GDS.Section_3_Cam = OS3.isOpen;

            SaveManagerSection.Save(GDS);
            print("Section Data Saved");
        }
        catch
        {
            print("SECTION DATA NOT SAVED");
        }
        
       
    }

    public void LoadGame()
    {
        try
        {
            /*if (Store_1.gameObject.activeSelf)*/
            Store_1.MaxCoinNeedToUnlock = GDS.Section_1;

            /*if (Store_2.gameObject.activeSelf)*/
            Store_2.MaxCoinNeedToUnlock = GDS.Section_2;

            /*if (Store_3.gameObject.activeSelf)*/
            Store_3.MaxCoinNeedToUnlock = GDS.Section_3;

            OS1.isOpen = GDS.Section_1_Cam;
            OS2.isOpen = GDS.Section_2_Cam;
            OS3.isOpen = GDS.Section_3_Cam;
        }
        catch
        {
            print("SECTION DATA NOT LOADED");
        }
    }
}
