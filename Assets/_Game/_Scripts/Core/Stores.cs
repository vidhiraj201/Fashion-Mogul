using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using FashionM.Control;


namespace FashionM.Core
{
    public class Stores : MonoBehaviour
    {
       
        private TextMeshPro text;
        public TextMeshPro RackPrice;
        public Image waitTimerUnlockUI;
        public Image waitTimerlockUI;
        public string StoreName;
        public int RackNumber;

        public float giveItemToPlayter;
        public float waitTimer = 1;
        public bool playerIsNear = false;
        public bool isRackClosed = false;
        public bool storeIsOpen = false;
        public float MaxCoinNeedToUnlock;        


        public bool PlayerIsOnClosedRack = false;
        private playerControl playerC;
        private GameManager gm;
        void Start()
        {
            playerC = FindObjectOfType<playerControl>();
            text = transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();
            waitTimerUnlockUI.gameObject.SetActive(false);
            waitTimerlockUI.gameObject.SetActive(false);
            giveItemToPlayter = waitTimer;
            loadWaitTimer = waitTimer;
            if (isRackClosed)
            {
                text.gameObject.SetActive(false);
                RackPrice.text = "$" + MaxCoinNeedToUnlock.ToString();
            }

            if(storeIsOpen)
                text.text = StoreName;


            gm = FindObjectOfType<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isRackClosed && !storeIsOpen)
            {
                whenPlayerIsOnRack();                
            }
            if(isRackClosed && !storeIsOpen)
                loadUSUI();


            if (MaxCoinNeedToUnlock <= 0 && isRackClosed)
                isRackClosed = false;

            if (!isRackClosed && storeIsOpen)
                giveItem();

        }


        public void whenPlayerIsOnRack()
        {
            
            text.gameObject.SetActive(true);
            RackPrice.gameObject.SetActive(false);
            text.text = StoreName;

            transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
            transform.localPosition = new Vector3(transform.localPosition.x, 5, transform.localPosition.z);
            storeIsOpen = true;
        }
        
        public void giveItem()
        {
            waitTimerUnlockUI.transform.forward = -Camera.main.transform.forward;

            if (playerIsNear)
            {
                giveItemToPlayter -= Time.deltaTime;
                waitTimerUnlockUI.gameObject.SetActive(true);
                waitTimerUnlockUI.fillAmount = giveItemToPlayter / waitTimer;
                if (giveItemToPlayter <= 0)
                {
                    playerC.StoreNumberStored = RackNumber;
                    playerIsNear = false;
                    giveItemToPlayter = waitTimer;
                    waitTimerUnlockUI.gameObject.SetActive(false);

                }
            }
        }

        float loadWaitTimer;
        bool loadedUI;
        public void loadUSUI()
        {
            waitTimerlockUI.transform.forward = -Camera.main.transform.forward;

            if (PlayerIsOnClosedRack && !loadedUI)
            {                
                loadWaitTimer -= Time.deltaTime;
                waitTimerlockUI.gameObject.SetActive(true);
                waitTimerlockUI.fillAmount = loadWaitTimer / waitTimer;
                if (loadWaitTimer <= 0 )
                {
                    loadWaitTimer = waitTimer;
                    gm.UnlockStoreUI.SetActive(true);                    
                    waitTimerlockUI.gameObject.SetActive(false);
                    loadedUI = true;
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") && isRackClosed)
            {
                PlayerIsOnClosedRack = true;
                    
            }

        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") && isRackClosed)
            {
                
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (playerIsNear)
            {
                playerIsNear = false;
                giveItemToPlayter = waitTimer;
                waitTimerUnlockUI.gameObject.SetActive(false);
            }


            if (PlayerIsOnClosedRack)
            {
                loadWaitTimer = waitTimer;
                waitTimerlockUI.fillAmount = loadWaitTimer / waitTimer;
                waitTimerlockUI.gameObject.SetActive(false);
                PlayerIsOnClosedRack = false;
                loadedUI = false;
                if (gm.UnlockStoreUI.activeSelf)
                    gm.UnlockStoreUI.GetComponent<Animator>().Play("Out");
            }

        }
    }
}
