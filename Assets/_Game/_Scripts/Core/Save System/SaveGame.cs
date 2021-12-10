using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class SaveGame : MonoBehaviour
{
    public float saveGame;

   public float save;

    private void Start()
    {
        save = saveGame;
    }
    void Update()
    {
        if (save >= 0)
            save -= Time.deltaTime;
        if (save <= 0)
        {
            save = saveGame;
            try
            {
                FindObjectOfType<SavingAndLoadingSection>().SaveGames();
                FindObjectOfType<SavingAndLoading>().SaveGame();                
                FindObjectOfType<SavingAndLoadingCasual>().SaveGame();
                FindObjectOfType<SavingAndLoadingBeach>().SaveGame();
                FindObjectOfType<SavingAndLoadingOffice>().SaveGame();
                FindObjectOfType<SavingAndLoadingSport>().SaveGame();
            }
            catch
            {

            }
        }
    }
}
