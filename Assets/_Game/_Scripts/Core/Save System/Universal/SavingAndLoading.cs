using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Control;
using FashionM.Core;
using FashionM.Movement;

public class SavingAndLoading : MonoBehaviour
{
    private GameManager gm;
    public BlackOutsForTutorial BOFT;

    public GameData gameData;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        gameData = SaveManager.Load();
        LoadGame();
    }

    public void SaveGame()
    {
        gameData.totalMoney = (int)gm.MaxCoin;
        gameData.DayCount = (gm.dayCount );
        gameData.totalEmployeeCount = (int)gm.EmployeeCount;
        gameData.EmployeeAmount = (int)gm.EmployeeAmount;
        gameData.isTutorialOver = gm.isTutorialOver;
        gameData.isFinalTutorialOver = gm.isFinalTutorialOver;
        gameData.do0 = BOFT.do0;
        gameData.do1 = BOFT.do1;
        gameData.do2 = BOFT.do2;
        gameData.do3 = BOFT.do3;
        SaveManager.Save(gameData);
        print("Universal Data Saved");
    }

    public void LoadGame()
    {
        gm.MaxCoin = gameData.totalMoney;
        gm.dayCount = gameData.DayCount;
        gm.EmployeeCount = gameData.totalEmployeeCount;
        gm.EmployeeAmount = gameData.EmployeeAmount;
         gm.isTutorialOver = gameData.isTutorialOver ;
         gm.isFinalTutorialOver = gameData.isFinalTutorialOver;
        BOFT.do0 = gameData.do0 ;
        BOFT.do1 = gameData.do1 ;
        BOFT.do2 = gameData.do2 ;
        BOFT.do3 = gameData.do3 ;
    }
}
