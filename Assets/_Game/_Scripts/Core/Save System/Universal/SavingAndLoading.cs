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
        gameData.DayCount = (gm.dayCount + 1);
        gameData.isTutorialOver = gm.isTutorialOver;
        gameData.isFinalTutorialOver = gm.isFinalTutorialOver;
        gameData.do1 = BOFT.do1;
        gameData.do2 = BOFT.do2;
        gameData.do3 = BOFT.do3;
        SaveManager.Save(gameData);
    }

    public void LoadGame()
    {
        gm.MaxCoin = gameData.totalMoney;
        gm.dayCount = gameData.DayCount;
         gm.isTutorialOver = gameData.isTutorialOver ;
         gm.isFinalTutorialOver = gameData.isFinalTutorialOver;
        BOFT.do1 = gameData.do1 ;
        BOFT.do2 = gameData.do2 ;
        BOFT.do3 = gameData.do3 ;
    }
}
