using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using FashionM.Movement;
using FashionM.Core;





namespace FashionM.Control
{
    public class clientControl : MonoBehaviour
    {
        public FashionM.Core.LevelManagerStore lv;
        [HideInInspector]public clientMovement CM;
        public GameObject coin;
        public Image waitTimerUI;

        /*public TextMeshPro T1;*/
        /*public Image Cloth;*/
        /*public Transform UIHolder;*/

        private GameObject ar;


        public bool startTreding = false;
        public bool TradeComp;
        public bool LeaveEmp;
        public bool clothTookFromEmpOrPlayer = false;  
        public bool tredingComplete = false;  
        public int NeedItem;


        public float CoinDropOffset;
        public float timerToTakeItemFromPlayer;
        public float waitTimer = 1;
        public bool playerIsNear = false;

        [HideInInspector]public bool coinSpwan = false;
        private GameManager gm;

        public bool StopWalking;
        public void Awake()
        {
           /* if (lv.rackOpen.Count > 0)
                clientNeedItemRandomize();*/
        }
        private void Start()
        {

            StopWalking = true;

            if (!lv.Customers.Contains(this.gameObject))
                lv.Customers.Add(this.gameObject);



            if (lv.rackOpen.Count > 0) 
                NeedItem = lv.rackOpen[0];

            timerToTakeItemFromPlayer = waitTimer;
            waitTimerUI.gameObject.SetActive(false);
            gm = FindObjectOfType<GameManager>();
            CM = GetComponent<clientMovement>();
            //clientNeedItemRandomize();
            try
            {
                ar = transform.GetChild(2).gameObject;
            }
            catch
            {

            }
           
        }

        //Customer Count from Level Manager Added
        [HideInInspector]public bool CCountAdded;
        [HideInInspector] public bool CCountAdd;
        [HideInInspector] public float t = 0.5f;
        public void completeTreding()
        {
            if (clothTookFromEmpOrPlayer && t >= 0)
            {

                t -= Time.deltaTime;
            }
            if (t <= 0)
            {
                t = 0;
                tredingComplete = true;
            }

            if (clothTookFromEmpOrPlayer && !CCountAdd)
            {
                gm.customerServed += 1;
                CCountAdd = true;
            }


        }
        private bool afterStart = false;
        float k = 0.5f;
        float l=0.5f;
        private void Update()
        {
            completeTreding();
            if (gm.dayCount == 1)
            {
                NeedItem = 1;
            }


            if (TradeComp && !coinSpwan)
            {
                Instantiate(coin, new Vector3(transform.position.x,transform.position.y + CoinDropOffset, transform.position.z), Quaternion.identity);
                coinSpwan = true;
            }

            if (gm.dayCount > 2 && ar != null)
                Destroy(ar);

            if(!LeaveEmp && TradeComp && l>0)
            {
                l -= Time.deltaTime;
                if (l <= 0)
                {
                    l = 0.5f;
                    LeaveEmp = true;
                }
            }

            if (lv.rackOpen.Count > 0&& !afterStart)
            {
                if (k >= 0)
                    k -= Time.deltaTime;
                if (k <= 0)
                {
                    clientNeedItemRandomize();
                    afterStart = true;
                }                
            }

            if (playerIsNear)
            {
                
                timerToTakeItemFromPlayer -= Time.deltaTime;

                if (timerToTakeItemFromPlayer <= waitTimer /2)
                {
                    GetComponent<clientMovement>().Anime.SetTrigger("Celeb");
                }

                if (timerToTakeItemFromPlayer <= 0)
                {
                    TradeComp = true;

                    playerIsNear = false;

                    timerToTakeItemFromPlayer = waitTimer;

                }
            }
        }

        private void FixedUpdate()
        {

           if (/*gm.customerGoal <= 0 &&*/ !CCountAdded)
            {
                StopWalking = true;
            }
            
        }

        public void clientNeedItemRandomize()
        {
            if (gm.dayCount != 1)
            {
                if (lv.rackOpen.Count == 1)
                {
                    NeedItem = lv.rackOpen[0];
                }
                if (lv.rackOpen.Count == 2)
                {
                    int a = Random.Range(0, 2);
                    NeedItem = lv.rackOpen[a];
                }

                if (lv.rackOpen.Count == 3)
                {
                    int a = Random.Range(0, 3);
                    NeedItem = lv.rackOpen[a];
                }
                if (lv.rackOpen.Count > 3)
                {
                    int a = Random.Range(0, 4);
                    NeedItem = lv.rackOpen[a];
                }
            }

            
            
        }
        [HideInInspector] public bool particalExplod;


        /*public void CheckForCustomer()
        {
            if(gm.customerGoal <= 0 && gm.Customer.Count > 0)
            {
                gm.Customer[gm.Customer.Count - 1].GetComponent<clientControl>().StopWalking = true;

                //gm.Customer.Remove(gm.Customer[gm.Customer.Count - 1]);
            }

           
        }*/
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("DoorChecker"))
            {
                if(/*gm.customerGoal > 0 &&*/ !CCountAdded && lv.Customers.Contains(this.gameObject))
                {
                    //clientNeedItemRandomize();
                    gm.CustomerIn += 1;
               /*     gm.customerGoal -= 1;*/
                    CCountAdded = true;
                    lv.Customers.Remove(this.gameObject);
                    
                }

                if (CCountAdded && clothTookFromEmpOrPlayer)
                {
                    StopWalking = true;
                    gm.CustomerOut += 1;
                    gm.CustomerIn -= 1;
                    CCountAdded = false;

                    if (!lv.Customers.Contains(this.gameObject))
                    {
                        lv.Customers.Add(this.gameObject);
                    }
                }

            }
            

            if (!gm.day2TutorialOver)
            {
                if (FindObjectOfType<tutorialUI>().StartCustomer.Count < 3 && !FindObjectOfType<tutorialUI>().StartCustomer.Contains(this.transform.gameObject))
                {
                    FindObjectOfType<tutorialUI>().StartCustomer.Add(this.transform.gameObject);
                }
            }
            
        }

        public GameObject remove()
        {
            return this.gameObject;
        }
        private void OnCollisionExit(Collision collision)
        {

           /* if (playerIsNear)
            {
                playerIsNear = false;
                startTreding = false;
                waitTimerUI.gameObject.SetActive(false);
                timerToTakeItemFromPlayer = waitTimer;
            }*/
        }
    }
}
