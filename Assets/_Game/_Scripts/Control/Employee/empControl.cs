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
        public int ClientNo;
        public GameObject TargetForClient;
        public GameObject TargetForStore;
        public bool Occupied;

        [Header("Treding")]
        public Stores OR;

        public float StoreNumberStored;

        private GameManager manager;
        void Start()
        {
            manager = FindObjectOfType<GameManager>();
        }

        void FixedUpdate()
        {
            /*if(!Occupied)
                FIndTargetForClient();*/

            /*if(Occupied)
                ResetTargetOfClient();*/

            /*if (TargetForClient != null )
                Occupied = true;*/

            if (TargetForClient == null)
                Occupied = false ;
            

        }

        void FIndTargetForClient()
        {           
            TargetForClient = FindObjectOfType<DummyScriptForClient>().gameObject;
            if (TargetForClient.GetComponent<ClientUitilities>().EmpNo <= 0)
            {                
                TargetForClient.GetComponent<ClientUitilities>().EmpNo = ClientNo;
                TargetForClient.GetComponent<ClientUitilities>().locked = true;
                Destroy(TargetForClient.GetComponent<DummyScriptForClient>());
            }
        }
        void ResetTargetOfClient()
        {
            if (TargetForClient.GetComponent<ClientUitilities>().EmpNo > 0 && TargetForClient.GetComponent<ClientUitilities>().EmpNo != ClientNo)
            {              
                TargetForClient = null;
            }
        }

        public Collider[] Racks;
        public void FindTargetForStore()
        {
             Racks = Physics.OverlapSphere(transform.position, 100);


        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Client"))
            {
                if (other.gameObject.GetComponent<clientControl>().clientNeedItem == StoreNumberStored)
                {
                    other.gameObject.GetComponent<clientControl>().startTreding = true;
                    other.gameObject.GetComponent<clientControl>().playerIsNear = true;
                }
            }

            if (other.gameObject.CompareTag("Racks"))
            {
                OR = other.gameObject.GetComponent<Stores>();
                if (OR != null && !OR.isRackClosed)
                    OR.playerIsNear = true;
            }

            if (other.gameObject.CompareTag("Coin"))
            {
                if (other.gameObject.GetComponent<Animator>() != null)
                {
                    other.gameObject.GetComponent<Animator>().SetTrigger("collect");
                    Destroy(other.gameObject.GetComponent<Collider>());
                    manager.MaxCoin += other.gameObject.GetComponent<DropCoin>().Coins;
                }
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Client"))
            {
                if (other.gameObject.GetComponent<clientControl>().clientNeedItem == StoreNumberStored)
                {
                    if (other.gameObject.GetComponent<clientControl>().takeItemFromPlayer <= 0.1f)
                    {
                        StoreNumberStored = 0;
                    }
                }
            }
        }
    }
}
