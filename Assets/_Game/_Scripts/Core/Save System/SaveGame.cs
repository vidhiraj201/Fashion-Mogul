using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                FindObjectOfType<SavingAndLoading>().SaveGame();                
                FindObjectOfType<SavingAndLoadingCasual>().SaveGame();
                FindObjectOfType<SavingAndLoadingBeach>().SaveGame();
                FindObjectOfType<SavingAndLoadingOffice>().SaveGame();
                FindObjectOfType<SavingAndLoadingSport>().SaveGame();
                FindObjectOfType<SavingAndLoadingSection>().SaveGames();
            }
            catch
            {

            }
        }
    }
}
