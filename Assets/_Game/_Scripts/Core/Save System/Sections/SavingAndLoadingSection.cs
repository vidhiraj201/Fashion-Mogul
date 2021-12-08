using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;

public class SavingAndLoadingSection : MonoBehaviour
{
    public StoreExpansion Store_1;
    public StoreExpansion Store_2;
    public StoreExpansion Store_3;

    public GameDataSection GDS;
    private void Awake()
    {
        LoadGame();
        GDS = SaveManagerSection.Load();
    }

    private void Update()
    {
        if (Store_1.gameObject.activeSelf && GDS.Section_1 <=0)
            Store_1.MaxCoinNeedToUnlock = GDS.Section_1;

        if (Store_2.gameObject.activeSelf && GDS.Section_2 <= 0)
            Store_2.MaxCoinNeedToUnlock = GDS.Section_3;

        if (Store_3.gameObject.activeSelf && GDS.Section_3 <= 0)
            Store_3.MaxCoinNeedToUnlock = GDS.Section_2;
    }

    public void SaveGames()
    {
        
        if (Store_1.gameObject.activeSelf)
            GDS.Section_1 = (int)Store_1.MaxCoinNeedToUnlock;

        if (Store_2.gameObject.activeSelf)
            GDS.Section_3 = (int)Store_2.MaxCoinNeedToUnlock;

        if (Store_3.gameObject.activeSelf)
            GDS.Section_2 = (int)Store_3.MaxCoinNeedToUnlock;

        SaveManagerSection.Save(GDS);
        print("Section Data Saved");
    }

    public void LoadGame()
    {
        if (Store_1.gameObject.activeSelf)
            Store_1.MaxCoinNeedToUnlock = GDS.Section_1;

        if (Store_2.gameObject.activeSelf)
            Store_2.MaxCoinNeedToUnlock = GDS.Section_3;

        if (Store_3.gameObject.activeSelf)
            Store_3.MaxCoinNeedToUnlock = GDS.Section_2;
    }
}
