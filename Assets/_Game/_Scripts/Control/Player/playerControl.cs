using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FashionM.Core;
using FashionM.Movement;


namespace FashionM.Control
{
    public class playerControl : MonoBehaviour        
    {
        //private TextMeshPro Text;
        public int StoreNumberStored = 0;
        private GameManager manager;
        public Stores OR;
        public StoreExpansion SE;
        public HRDesk HR;

        public Transform Arrow; 
        private void Start()
        {
            //Text = transform.GetChild(1).GetComponent<TextMeshPro>();
            manager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            /* if(StoreNumberStored>=1)
                 Text.text = StoreNumberStored.ToString();

             if (StoreNumberStored <= 0)
                 Text.text = "".ToString();*/
            tutorial();

        }

        [HideInInspector] public bool particalExplod;
        void tutorial()
        {
            if (FindObjectOfType<GameManager>().DayStart && Arrow!=null && !FindObjectOfType<FashionM.Core.GameManager>().isFinalTutorialOver)
            {
                Arrow.gameObject.SetActive(true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Coin"))
                FindObjectOfType<AudioManager>().source.PlayOneShot(FindObjectOfType<AudioManager>().CollectMoney, 0.3f);
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Client"))
            {
                if(other.gameObject.GetComponent<clientMovement>().reched && !other.gameObject.GetComponent<clientControl>().clothTookFromEmpOrPlayer)
                GetComponent<playerStackingSystem>().RemoveCloth(other);

            /*    if (other.gameObject.GetComponent<clientControl>().NeedItem == StoreNumberStored )
                {
                    other.gameObject.GetComponent<clientControl>().startTreding = true;
                    other.gameObject.GetComponent<clientControl>().playerIsNear = true;
                    other.gameObject.GetComponent<clientControl>().tredingComplete = true;
                    StoreNumberStored = 0;
                }*/
            }

         /*   if (other.gameObject.CompareTag("Coin"))
                FindObjectOfType<AudioManager>().source.PlayOneShot(FindObjectOfType<AudioManager>().CollectMoney, .5f);
*/
            if (other.gameObject.CompareTag("HR"))
            {
                HR = other.gameObject.GetComponent<HRDesk>();
            }
                
        }

        private void OnCollisionStay(Collision other)
        {

            if (other.gameObject.CompareTag("Racks") && GetComponent<FashionM.Movement.playerMovement>().direction.magnitude < 0.1f)
            {
                OR = other.gameObject.GetComponent<Stores>();
                if (OR != null && !OR.isRackClosed)
                    OR.playerIsNear = true;
            }


            if (other.gameObject.CompareTag("HR"))
            {
                HR = other.gameObject.GetComponent<HRDesk>();
            }
            /*     if (other.gameObject.CompareTag("Client"))
                 {
                     if (other.gameObject.GetComponent<clientControl>().NeedItem == StoreNumberStored)
                     {                    
                             StoreNumberStored = 0;
                         *//*if (other.gameObject.GetComponent<clientControl>().timerToTakeItemFromPlayer <= 0.1f)
                         {
                         }*//*
                     }
                 }*/

            if (other.gameObject.CompareTag("Racks") && GetComponent<FashionM.Movement.playerMovement>().direction.magnitude < 0.1f)
            {
                if (OR != null && !OR.isRackClosed && !OR.playerIsNear)
                    OR.playerIsNear = true;
            }

            if (other.gameObject.CompareTag("StoreExp") && manager.dayCount>=4)
            {
                SE = other.gameObject.GetComponent<StoreExpansion>();
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            SE = null;
            HR = null;
        }
    }
}
