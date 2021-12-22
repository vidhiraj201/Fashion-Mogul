﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using FashionM.Control;


namespace FashionM.Core
{
    public class Stores : MonoBehaviour
    {
        public float baseS;
        public int RackCodeNumber;
        public LevelManagerStore lv;
        public TextMeshPro RackPrice;

        public Image waitTimerUnlockUI;

        public GameObject StoreGFX;
        public GameObject PurchesGFX;
        public GameObject Cloth;
        public Material mat;
        


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
        public bool Rack0;
        public bool Rack1;
        public bool Rack2;
        public bool Rack3;

        private playerControl playerC;
        private GameManager gm;

        public float Y = 3.29f;
        private void Awake()
        {
            gm = FindObjectOfType<GameManager>();
            playerC = FindObjectOfType<playerControl>();
        }
        void Start()            
        {
            
            waitTimerUnlockUI.gameObject.SetActive(false);
            
            giveItemToPlayter = waitTimer;
            
            if (isRackClosed)
            {
                RackPrice.text = "$" + MaxCoinNeedToUnlock.ToString();
                StoreGFX.SetActive(false);
                PurchesGFX.SetActive(true);
            }
        }

        public bool unlock;
        // Update is called once per frame
        void Update()
        {
            if (!isRackClosed && !storeIsOpen)
            {
                whenPlayerIsOnRack();                
            }


            if (MaxCoinNeedToUnlock <= 0 && isRackClosed)

            {               
                isRackClosed = false;             
            }
            if(MaxCoinNeedToUnlock <= 0 && !unlock)
            {
                unlock = true;
            }
            if (unlock)
            {                
                MaxCoinNeedToUnlock = 0;
            }
            if (!isRackClosed && storeIsOpen)
                giveItem();

        }

        public void CheckStore()
        {
            if (Rack0)
            {
                lv.Rack0 = true;
            }

            if (Rack1)
            {
                lv.Rack1 = true;
            }
            if (Rack2)
            {
                lv.Rack2 = true;
            }
            if (Rack3)
            {
                lv.Rack3 = true;
            }
        }

        public void whenPlayerIsOnRack()
        {
            FindObjectOfType<AudioManager>().source.PlayOneShot(FindObjectOfType<AudioManager>().MoneyCounting, 0.5f);
            RackPrice.gameObject.SetActive(false);
            StoreGFX.SetActive(true);
            PurchesGFX.GetComponent<MeshRenderer>().enabled = false;
            Destroy(PurchesGFX, 0.2f);
            transform.localScale = new Vector3(transform.localScale.x, 0.75f, transform.localScale.z);
            transform.localPosition = new Vector3(transform.localPosition.x, Y, transform.localPosition.z);
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
                    playerC.GetComponent<playerStackingSystem>().addClothToStack(RackNumber, mat, Cloth);
                    playerIsNear = false;
                    giveItemToPlayter = waitTimer;
                    waitTimerUnlockUI.gameObject.SetActive(false);
                }
            }
        }

       
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") && isRackClosed && collision.gameObject.GetComponent<FashionM.Movement.playerMovement>().direction.magnitude <= 0)
            {
                PlayerIsOnClosedRack = true;                    
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") && isRackClosed)
            {
                if (gm.MaxCoin >= MaxCoinNeedToUnlock && MaxCoinNeedToUnlock >= 0 && collision.gameObject.GetComponent<FashionM.Movement.playerMovement>().direction.magnitude<=0)
                {
                    MaxCoinNeedToUnlock -= CoinReduceSpeed*20;
                    gm.MaxCoin -= CoinReduceSpeed*20;
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
                PlayerIsOnClosedRack = false;
            }

        }
    }
}
