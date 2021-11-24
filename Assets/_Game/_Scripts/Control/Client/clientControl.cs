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
        public GameObject coin;
        public TextMeshPro T1;
        public Image waitTimerUI;
        public Transform UIHolder;



        public bool startTreding = false;
        public bool TradeComp;
        public bool tredingComplete = false;  
        public int NeedItem;


        public float CoinDropOffset;
        public float timerToTakeItemFromPlayer;
        public float waitTimer = 1;
        public bool playerIsNear = false;

        [HideInInspector]public bool coinSpwan = false;
        private GameManager gm;

        public bool StopeWalking;
        private void Start()
        {
            timerToTakeItemFromPlayer = waitTimer;
            waitTimerUI.gameObject.SetActive(false);
            gm = FindObjectOfType<GameManager>();
            clientNeedItemRandomize();
        }

        //Customer Count from Level Manager Added
        [HideInInspector]public bool CCountAdded;
        private void Update()
        {
            //waitTimerUI.transform.forward = Camera.main.transform.forward;
            UIHolder.forward = Camera.main.transform.forward;
            
            if (TradeComp && !coinSpwan)
            {
                Instantiate(coin, new Vector3(transform.position.x,transform.position.y + CoinDropOffset, transform.position.z), Quaternion.identity);
                coinSpwan = true;
            }

            T1.text = NeedItem.ToString();
            if (tredingComplete)
            {
                GetComponent<clientMovement>().PurchesUI.SetActive(false);

                
            }

            

            if (playerIsNear)
            {
                
                timerToTakeItemFromPlayer -= Time.deltaTime;

                if (timerToTakeItemFromPlayer <= waitTimer /2)
                {
                    GetComponent<clientMovement>().Anime.SetTrigger("Celeb");
                }
                //waitTimerUI.gameObject.SetActive(true);
                //waitTimerUI.fillAmount = timerToTakeItemFromPlayer / waitTimer;
                if (timerToTakeItemFromPlayer <= 0)
                {
                    TradeComp = true;
                    //GetComponent<ClientUitilities>().stopTrade();
                    playerIsNear = false;
                    //waitTimerUI.gameObject.SetActive(false);
                    timerToTakeItemFromPlayer = waitTimer;
                }
            }
        }

        private void FixedUpdate()
        {
            if (gm.CustomerIn <= gm.customerGoal)
                StopeWalking = false;

            if (gm.CustomerIn >= gm.customerGoal && !CCountAdded)
            {
                StopeWalking = true;
                //StartCoroutine(edlay(0.5f));
            }

/*
            if (NeedItem == 0 && !tredingComplete)
                clientNeedItemRandomize();*/

            if (!GetComponent<clientMovement>().reched)
            {
                gameObject.layer = 17;
            }
            if (GetComponent<clientMovement>().reched && !startTreding)
            {
                gameObject.layer = 10;
                startTreding = true;
            }
        }

        public void clientNeedItemRandomize()
        {
            if (lv.rackOpen.Count == 0)
                return;
            if (lv.rackOpen.Count <= 1)
            {
                print("one Item");
                NeedItem = lv.rackOpen[0];
            }

            if (lv.rackOpen.Count >= 2)
            {
                int a = Random.Range(lv.rackOpen[0], lv.rackOpen[lv.rackOpen.Count-1]);
                NeedItem = lv.rackOpen[a];


                print(NeedItem);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("DoorChecker"))
            {
                if (!CCountAdded)
                {
                    gm.CustomerIn += 1;
                    CCountAdded = true;
                }

                if (CCountAdded && tredingComplete)
                {
                    gm.CustomerOut += 1;
                    CCountAdded = false;
                }

                if (gm.CustomerIn >= gm.customerGoal+1)
                    StopeWalking = true;
            }
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
