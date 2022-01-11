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

            if (GetComponent<empControl>().StoreNumberStored > 0 && GetComponent<EmpStackingSystem>().ClothObject.Count <= 0)
                GetComponent<empControl>().StoreNumberStored = -1;
        }

        public GameObject customer;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Client") )
            {
                customer = other.gameObject;

                if(!other.gameObject.GetComponent<clientControl>().clothTookFromEmpOrPlayer && other.gameObject.GetComponent<clientMovement>().reched)
                {                    
                    if (other.gameObject.GetComponent<clientControl>().NeedItem != StoreNumberStored || other.gameObject.GetComponent<clientControl>().NeedItem != GetComponent<empMovement>().ClientNeedItem)
                    {
                        StoreNumberStored = -1;
                        GetComponent<EmpStackingSystem>().poofCloth();
                        GetComponent<empMovement>().ClientNeedItem = other.gameObject.GetComponent<clientControl>().NeedItem;
                    }
                    if (GetComponent<EmpStackingSystem>().ClothObject.Count <= 0)
                    {
                        StoreNumberStored = -1;
                        GetComponent<empMovement>().ClientNeedItem = other.gameObject.GetComponent<clientControl>().NeedItem;
                    }
                }

                if (!other.gameObject.GetComponent<clientControl>().clothTookFromEmpOrPlayer && other.gameObject.GetComponent<clientMovement>().reched)
                {
                    GetComponent<EmpStackingSystem>().RemoveCloth(other);
                }
                
                if (other.gameObject.GetComponent<clientControl>().tredingComplete)
                {
                    GetComponent<empMovement>().ClientNeedItem = -1;
                }


           /*     GetComponent<empMovement>().ClientNeedItem = -1;
                if (other.gameObject.GetComponent<clientControl>().startTreding)
                {
                    if (other.gameObject.GetComponent<clientControl>().NeedItem != StoreNumberStored && !TradeStarted)
                    {
                        StoreNumberStored = -1;
                        //GetComponent<empMovement>().ClientNeedItem = -1;

                        if (GetComponent<empMovement>().ClientNeedItem <= -1)
                        {
                            GetComponent<empMovement>().ClientNeedItem = other.gameObject.GetComponent<clientControl>().NeedItem;
                            TradeStarted = true;
                        }

                        GetComponent<empMovement>().isWalkingTowardClient = false;
                    }
                }
*/


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
                    if(a>=0 && StoreNumberStored <= -1)
                        a -= Time.deltaTime;

                    if (a <= 0)
                    {
                        a = 0.5f;
                        StoreNumberStored = OR.RackNumber;
                        GetComponent<EmpStackingSystem>().addClothToStack(OR.RackNumber, OR.mat,OR.Cloth);
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
