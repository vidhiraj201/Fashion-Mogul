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
        public bool TargetLock;
        public bool T;
        [Header("Treding")]
        public float StoreNumberStored;

        void Start()
        {

        }

        void FixedUpdate()
        {
            if(!TargetLock)
                FIndTargetForClient();

            if(TargetLock)
                ResetTargetOfClient();

            if (TargetForClient != null )
                TargetLock = true;

            if (TargetForClient == null)
                TargetLock = false ;
            
            FindTargetForStore();

            if (Input.GetKeyDown(KeyCode.E) && T)
            {
                TargetForClient = null;
                TargetLock = false;
            }

        }

        void FIndTargetForClient()
        {           
            TargetForClient = FindObjectOfType<DummyScriptForClient>().gameObject;
            if (TargetForClient.GetComponent<Uitilities>().EmpNo <= 0)
            {                
                TargetForClient.GetComponent<Uitilities>().EmpNo = ClientNo;
                TargetForClient.GetComponent<Uitilities>().locked = true;
                Destroy(TargetForClient.GetComponent<DummyScriptForClient>());
            }
        }
        void ResetTargetOfClient()
        {
            if (TargetForClient.GetComponent<Uitilities>().EmpNo > 0 && TargetForClient.GetComponent<Uitilities>().EmpNo != ClientNo)
            {              
                TargetForClient = null;
            }
        }

        public Collider[] Racks;
        public void FindTargetForStore()
        {
             Racks = Physics.OverlapSphere(transform.position, 100);

            foreach (Collider hitCollider in Racks)
            {

                /*if (hitCollider.tag == "Racks")
                    Debug.Log("Hello");*/
                
                /*if(hitCollider.GetComponent<Stores>().RackNumber == TargetForClient.GetComponent<clientControl>().clientNeedItem)
                {
                    TargetForStore = hitCollider.gameObject;
                }*/
            }

/*            if (FindObjectOfType<Stores>().RackNumber == TargetForClient.GetComponent<clientControl>().clientNeedItem)
            {
                TargetForStore = FindObjectOfType<Stores>().gameObject;
            }

*/
        }
    }
}
