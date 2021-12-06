using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

namespace FashionM.Core
{
   public class StoreExpansion : MonoBehaviour
    {

        private UniqueID uniqueID;
        private ExpandedStoreData expdData;


        public LevelManagerStore lv;
        public TextMeshPro StoreStatus;

        public TextMeshPro StoreUpgradesPrice;
        public TextMeshPro StoreUpgradesPrice_1;
        public Image WaitTimerUnlockUI;
        public Image WaitTimerUnlockUI_1;


        public float WaitTimer=1;
        private float UIUnlock;
        private bool isPlayerNear;

       [Tooltip("0- L&R Facing \n 1- L Facing \n 2- R Facing \n 3- Facing")]
        public int facingSide;


        public float CoinReduceSpeed = 1;
        public float MaxCoinNeedToUnlock;
        private GameObject Bounds;

        private GameManager GM;

        public float xPos;
        public float zPos;
        public Vector3 PlacingRotation;
        public Vector3 PlacingPosition;

        [Header ("Collider Bound")]
        public Vector3 BoundCenter;
        public Vector3 BoundSize;


        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {

            uniqueID = GetComponent<UniqueID>();
            expdData = FindObjectOfType<ExpandedStoreData>();
            GM = FindObjectOfType<GameManager>();
            Bounds = GM.Bound;
            //StoreStatus.text = "Store Locked";
            StoreUpgradesPrice.text = "$" + MaxCoinNeedToUnlock;
            StoreUpgradesPrice_1.text = "$" + MaxCoinNeedToUnlock;

/*
            StoreUpgradesPrice.gameObject.SetActive(false);
            StoreUpgradesPrice_1.gameObject.SetActive(false);*/
            WaitTimerUnlockUI.gameObject.SetActive(false);
            WaitTimerUnlockUI_1.gameObject.SetActive(false);

            UIUnlock = WaitTimer;

            xPos = -55.5f;
            zPos = 55.5f;


            if (expdData.storedStore.Contains(uniqueID.ID))
            {
                Spwan();
                //MaxCoinNeedToUnlock = 0;
                Destroy(this.gameObject);
                return;
            }


        }

        public bool X, Z;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                GameObject.Find("Expanded Store").GetComponent<NavMeshSurface>().BuildNavMesh();
            }


            if (MaxCoinNeedToUnlock <= 0)
            {
                /*Bounds.transform.localScale = new Vector3(24,10,131);
                Bounds.transform.localPosition = new Vector3(-35.76f,39.3f,-36.45f);*/

                    if (X)
                    {
                        Bounds.GetComponent<BoxCollider>().center = new Vector3(BoundCenter.x, Bounds.GetComponent<BoxCollider>().center.y, Bounds.GetComponent<BoxCollider>().center.z); 
                        Bounds.GetComponent<BoxCollider>().size = new Vector3(BoundSize.x, Bounds.GetComponent<BoxCollider>().size.y, Bounds.GetComponent<BoxCollider>().size.z); 
                    }

                    if (Z)
                    {
                        Bounds.GetComponent<BoxCollider>().center = new Vector3(Bounds.GetComponent<BoxCollider>().center.x, Bounds.GetComponent<BoxCollider>().center.y, BoundCenter.z ); 
                        Bounds.GetComponent<BoxCollider>().size = new Vector3(Bounds.GetComponent<BoxCollider>().size.x, Bounds.GetComponent<BoxCollider>().size.y, BoundSize.z); 
                    }                
                Destroy(this.gameObject);
            }
            OpenUI();
        }


        /*public void HitButton()
        {
            MaxCoinNeedToUnlock = 0;
        }*/

        public void OpenUI()
        {
            WaitTimerUnlockUI.transform.forward = -Camera.main.transform.forward;
            if (isPlayerNear)
            {
                UIUnlock -= Time.deltaTime;
                

                WaitTimerUnlockUI.gameObject.SetActive(true);
                WaitTimerUnlockUI_1.gameObject.SetActive(true);


                WaitTimerUnlockUI_1.fillAmount = UIUnlock / WaitTimer;
                WaitTimerUnlockUI.fillAmount = UIUnlock / WaitTimer;
                if (UIUnlock <= 0)
                {
                    isPlayerNear = false;
                    UIUnlock = WaitTimer;
                    expdData.storedStore.Add(uniqueID.ID);
                    Spwan();
                  /*  WaitTimerUnlockUI.gameObject.SetActive(false);
                    if (WaitTimerUnlockUI_1 != null)
                        WaitTimerUnlockUI_1.gameObject.SetActive(false);*/
                        //GM.UnlockStoreExpansionUI.SetActive(true);

                    }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isPlayerNear = true;
/*                StoreUpgradesPrice.gameObject.SetActive(true);
                StoreUpgradesPrice_1.gameObject.SetActive(true);*/
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                StoreUpgradesPrice.gameObject.SetActive(true);
                StoreUpgradesPrice_1.gameObject.SetActive(true);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            
            if (isPlayerNear)
            {
                isPlayerNear = false;                
                UIUnlock = WaitTimer;
            }
/*            if (StoreUpgradesPrice.gameObject.activeSelf)
                StoreUpgradesPrice.gameObject.SetActive(false);

            if (StoreUpgradesPrice_1.gameObject.activeSelf)
                StoreUpgradesPrice_1.gameObject.SetActive(false);*/

            if (WaitTimerUnlockUI.gameObject.activeSelf)
                WaitTimerUnlockUI.gameObject.SetActive(false);

            if(WaitTimerUnlockUI_1 != null &&WaitTimerUnlockUI_1.gameObject.activeSelf)
                WaitTimerUnlockUI_1.gameObject.SetActive(false);

            if (GM.UnlockStoreExpansionUI.activeSelf)
                GM.UnlockStoreExpansionUI.GetComponent<Animator>().Play("Out");

        }

        [Header("Temp")]
        public int StationCountData;
        public GameObject ToSpwan;
     
        public void Spwan()
        {
            if (GM.MaxCoin >= MaxCoinNeedToUnlock && MaxCoinNeedToUnlock >= 0)
            {
                FindObjectOfType<AudioManager>().source.PlayOneShot(FindObjectOfType<AudioManager>().MoneyCounting, 0.5f);
                GameObject ToSpwanData = Instantiate(ToSpwan, PlacingPosition, Quaternion.Euler(PlacingRotation));
                ToSpwanData.transform.parent = GameObject.Find("Expanded Store").transform;
                if (!expdData.ExpandedData.Contains(ToSpwanData))
                {
                    expdData.ExpandedData.Add(ToSpwanData);
                }

                if (!expdData.storedStore.Contains(uniqueID.ID))
                {
                    GM.MaxCoin -= MaxCoinNeedToUnlock;
                    MaxCoinNeedToUnlock = 0;
                }

                if (expdData.storedStore.Contains(uniqueID.ID))
                {
                    //GM.MaxCoin -= MaxCoinNeedToUnlock;
                    MaxCoinNeedToUnlock = 0;
                    if (X)
                    {
                        Bounds.GetComponent<BoxCollider>().center = new Vector3(BoundCenter.x, Bounds.GetComponent<BoxCollider>().center.y, Bounds.GetComponent<BoxCollider>().center.z);
                        Bounds.GetComponent<BoxCollider>().size = new Vector3(BoundSize.x, Bounds.GetComponent<BoxCollider>().size.y, Bounds.GetComponent<BoxCollider>().size.z);
                    }

                    if (Z)
                    {
                        Bounds.GetComponent<BoxCollider>().center = new Vector3(Bounds.GetComponent<BoxCollider>().center.x, Bounds.GetComponent<BoxCollider>().center.y, BoundCenter.z);
                        Bounds.GetComponent<BoxCollider>().size = new Vector3(Bounds.GetComponent<BoxCollider>().size.x, Bounds.GetComponent<BoxCollider>().size.y, BoundSize.z);
                    }
                }                
            }
        }
    }
}
