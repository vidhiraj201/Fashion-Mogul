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
       
        private TextMeshPro StoreNameText;
        public TextMeshPro RackPrice;

        public Image waitTimerUnlockUI;
        public GameObject StoreGFX;

        //public Image waitTimerlockUI;

        public string StoreName;

        public int RackNumber;

        public float giveItemToPlayter;
        public float waitTimer = 1;
        public float CoinReduceSpeed;
        public float MaxCoinNeedToUnlock;        

        public bool playerIsNear = false;
        public bool EmpIsNear = false;
        public bool isRackClosed = false;
        public bool storeIsOpen = false;


        public bool PlayerIsOnClosedRack = false;


        [Header("Logic For Store")]
        public bool basicCloths;
        public bool premiumCloths;
        public bool exclusiveBrand;
        public bool jewllry;

        private playerControl playerC;
        private GameManager gm;
        void Start()
        {
            
            playerC = FindObjectOfType<playerControl>();
            StoreNameText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();
            waitTimerUnlockUI.gameObject.SetActive(false);
            //1waitTimerlockUI.gameObject.SetActive(false);
            giveItemToPlayter = waitTimer;
            //loadWaitTimer = waitTimer;
            if (isRackClosed)
            {
                StoreNameText.gameObject.SetActive(false);
                RackPrice.text = "$" + MaxCoinNeedToUnlock.ToString();
                StoreGFX.SetActive(false);
            }

            if(storeIsOpen)
                StoreNameText.text = StoreName;


            gm = FindObjectOfType<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isRackClosed && !storeIsOpen)
            {
                whenPlayerIsOnRack();                
            }
            /*if(isRackClosed && !storeIsOpen)
                whenPlayerIsOnRack();*/


            if (MaxCoinNeedToUnlock <= 0 && isRackClosed)
                isRackClosed = false;

            if (!isRackClosed && storeIsOpen)
                giveItem();

        }

        public void CheckStore()
        {
            if (premiumCloths)
            {
                gm.premiumCloths = true;
            }
            if (exclusiveBrand)
            {
                gm.exclusiveBrand = true;
            }
            if (jewllry)
            {
                gm.jewllry = true;
            }
        }

        public void whenPlayerIsOnRack()
        {            
            StoreNameText.gameObject.SetActive(false);
            RackPrice.gameObject.SetActive(false);
            StoreNameText.text = StoreName;
            StoreGFX.SetActive(true);
            transform.localScale = new Vector3(transform.localScale.x, 0.75f, transform.localScale.z);
            transform.localPosition = new Vector3(transform.localPosition.x, 3.5f, transform.localPosition.z);
            CheckStore();
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
                    playerC.GetComponent<playerStackingSystem>().addClothToStack(RackNumber);
                    playerIsNear = false;
                    giveItemToPlayter = waitTimer;
                    waitTimerUnlockUI.gameObject.SetActive(false);
                }
            }
        }

        /*float loadWaitTimer;
        bool loadedUI;*/
        /*public void loadUSUI()
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
                    gm.UnlockStoreExpansionUI.SetActive(true);                    
                    waitTimerlockUI.gameObject.SetActive(false);
                    loadedUI = true;
                }
            }
        }*/
       
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
                if(gm.MaxCoin >= MaxCoinNeedToUnlock || MaxCoinNeedToUnlock >= 0)
                {
                    MaxCoinNeedToUnlock -= CoinReduceSpeed;
                    gm.MaxCoin -= CoinReduceSpeed;
                    RackPrice.text = "$" + MaxCoinNeedToUnlock;
                }
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
                /*loadWaitTimer = waitTimer;
                waitTimerlockUI.fillAmount = loadWaitTimer / waitTimer;
                waitTimerlockUI.gameObject.SetActive(false);*/
                PlayerIsOnClosedRack = false;
               /* loadedUI = false;
                if (gm.UnlockStoreExpansionUI.activeSelf)
                    gm.UnlockStoreExpansionUI.GetComponent<Animator>().Play("Out");*/
            }

        }
    }
}
