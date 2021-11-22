using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Movement;
using FashionM.Core;

namespace FashionM.Control
{
    public class empControl : MonoBehaviour
    {
        [Header("Detection of Clients")]
        public GameObject TargetForClient;
        public bool Occupied;

        [Header("Treding")]
        public Stores OR;
        public bool TradeStarted = false;

        public float StoreNumberStored;
        private GameManager manager;

        void Start()
        {
            manager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            if (!Occupied)
            {
                TargetForClient = null;
                OR = null;
            }
            if (Occupied)
            {
                TargetForClient.gameObject.layer = 12;
                transform.gameObject.layer = 11;

            }
        }
        private void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.CompareTag("Client"))
            {
                if (other.gameObject.GetComponent<clientControl>().NeedItem != StoreNumberStored || other.gameObject.GetComponent<clientControl>().NeedItem != GetComponent<empMovement>().ClientNeedItem)
                {
                    print(transform.name + " " + other.gameObject.GetComponent<clientControl>().NeedItem + " " + StoreNumberStored);
                    if (other.gameObject.GetComponent<clientControl>().startTreding && GetComponent<EmpStackingSystem>().ClothObject.Count >0)
                    {
                        StoreNumberStored = other.gameObject.GetComponent<clientControl>().NeedItem;
                        GetComponent<EmpStackingSystem>().ClothObject[0].GetComponent<Cloths>().ClothIdentityNumber = other.gameObject.GetComponent<clientControl>().NeedItem; 
                    }
                }
            }





            if (other.gameObject.CompareTag("Client"))
            {
                triggerWhenNearClient(other);
                GetComponent<EmpStackingSystem>().RemoveCloth(other);

                if (other.gameObject.GetComponent<clientControl>().startTreding)
                {
                    if (other.gameObject.GetComponent<clientControl>().NeedItem != StoreNumberStored && !TradeStarted)
                    {
                        StoreNumberStored = 0;
                        GetComponent<empMovement>().ClientNeedItem = 0;
                        if (GetComponent<empMovement>().ClientNeedItem <= 0)
                        {
                            GetComponent<empMovement>().ClientNeedItem = other.gameObject.GetComponent<clientControl>().NeedItem;
                            TradeStarted = true;
                        }

                        GetComponent<empMovement>().isWalkingTowardClient = false;
                    }
                }


                
            }

            if (other.gameObject.CompareTag("Racks"))
            {
                try
                {
                    OR = other.gameObject.GetComponent<Stores>();                
                }
                catch
                {
                    print("Store Script is missing");
                }
            }
        }


        float a = 0.5f;
        private void OnCollisionStay(Collision other)
        {

            if (other.gameObject.CompareTag("Racks"))
            {
                OR = other.gameObject.GetComponent<Stores>();
                if (OR != null && !OR.isRackClosed)
                {
                    if(a>=0 && StoreNumberStored <= 0)
                        a -= Time.deltaTime;

                    if (a <= 0)
                    {
                        a = 0.5f;
                        StoreNumberStored = OR.RackNumber;
                        GetComponent<EmpStackingSystem>().addClothToStack(OR.RackNumber);
                        GetComponent<empMovement>().isWalkingTowardStore = false;
                        GetComponent<empMovement>().isWalkingTowardClient = true;
                    }                    
                }
            }
        }



        public void triggerWhenNearClient( Collision other)
        {
            GetComponent<empMovement>().ClientNeedItem =  other.gameObject.GetComponent<clientControl>().NeedItem;
            /*transform.gameObject.layer = 11;
            other.gameObject.layer = 12;*/
        }
    }
}
