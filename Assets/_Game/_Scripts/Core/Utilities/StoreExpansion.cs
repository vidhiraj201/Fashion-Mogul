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
            GM = FindObjectOfType<GameManager>();
            Bounds = GM.Bound;
            //StoreStatus.text = "Store Locked";
            StoreUpgradesPrice.text = "$" + MaxCoinNeedToUnlock;
            StoreUpgradesPrice_1.text = "$" + MaxCoinNeedToUnlock;

            WaitTimerUnlockUI.gameObject.SetActive(false);
            WaitTimerUnlockUI_1.gameObject.SetActive(false);

            UIUnlock = WaitTimer;

            xPos = -55.5f;
            zPos = 55.5f;

        }

        public bool X, Z;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                GameObject.Find("Expanded Store").GetComponent<NavMeshSurface>().BuildNavMesh();
            }


            if (MaxCoinNeedToUnlock <= 0)
            {                
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

                StartCoroutine(Deactive());
            }
            OpenUI();
        }

        IEnumerator Deactive()
        {
            FindObjectOfType<SavingAndLoadingSection>().SaveGames();
            yield return new WaitForSeconds(0.1f);
            Spwan();
            this.gameObject.SetActive(false);
        }

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
                    GM.MaxCoin -= MaxCoinNeedToUnlock;
                    MaxCoinNeedToUnlock = 0;
                }
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") && FindObjectOfType<FashionM.Movement.playerMovement>().direction.magnitude<0.1f)
            {
                isPlayerNear = true;

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
            }
        }
    }
}
