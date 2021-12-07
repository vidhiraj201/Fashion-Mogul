using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using FashionM;

namespace FashionM.Core
{
    public class SaveManager : MonoBehaviour
    {
        private Movement.playerMovement playerM;
        private Core.GameManager gameManager;
        public BlackOutsForTutorial BOFT;


        // Start is called before the first frame update
        void Awake()
        {
            if(!File.Exists(Application.dataPath + "/save.text"))
            {

            }

            playerM = GameObject.Find("Player").GetComponent<Movement.playerMovement>();
            gameManager = GameObject.Find("GameManager").GetComponent<Core.GameManager>();
            Load();

           SaveGameData saveGame = new SaveGameData {};
            string saveString =  JsonUtility.ToJson(saveGame);
            //print(saveString);

            SaveGameData loadedSaveGame = JsonUtility.FromJson<SaveGameData>(saveString);
            //print(loadedSaveGame.TotalAmount +" "+loadedSaveGame.playerPosition);
        }

/*        private void OnApplicationQuit()
        {
            //
        }*/

        public float time = 20;
        void Update()
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
            }
            if (time <= 0)
            {
                Save();
                time = 30;
            }
        }

        private void Save()
        {
            Vector3 PlayerPosition = playerPosition();
            Vector3 PlayerRotation = playerRotation();

            int TotalMoney = (int)gameManager.MaxCoin;
            SaveGameData saveGame = new SaveGameData
            {
                TotalAmount = (int)gameManager.MaxCoin,
                playerPosition = PlayerPosition,
                isTutorialOver = gameManager.isTutorialOver,
                isFinalTutorialOver = gameManager.isFinalTutorialOver,
                DayCount = gameManager.dayCount,
                do1 = BOFT.do1,
                do2 = BOFT.do2,
                do3 = BOFT.do3
            };
            string saveString = JsonUtility.ToJson(saveGame);
            File.WriteAllText(Application.dataPath + "/save.text", saveString);
            print("Game Saved");
        }

        private void Load()
        {
            if(File.Exists(Application.dataPath + "/save.text"))
            {
                string saveString = File.ReadAllText(Application.dataPath + "/save.text");

                SaveGameData saveGame =  JsonUtility.FromJson<SaveGameData>(saveString);
                gameManager.MaxCoin = saveGame.TotalAmount;

                gameManager.isTutorialOver = saveGame.isTutorialOver;
                gameManager.isFinalTutorialOver = saveGame.isFinalTutorialOver;
                gameManager.dayCount = saveGame.DayCount;
                BOFT.do1 = saveGame.do1;
                BOFT.do2 = saveGame.do2;
                BOFT.do3 = saveGame.do3;
                
            }
        }
 

        Vector3 playerPosition()
        {
            Vector3 playerPos = playerM.transform.position;
            return playerPos;
        }
        Vector3 playerRotation()
        {
            Vector3 playerRot = playerM.transform.eulerAngles;
            return playerRot;
        }
    }
     class SaveGameData
    {
        public int TotalAmount;
        public int DayCount;
        public Vector3 playerPosition;

        public bool isTutorialOver, isFinalTutorialOver;

        public bool do1, do2, do3;
    }
}


