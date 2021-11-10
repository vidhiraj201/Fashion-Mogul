using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FashionM.Control;

namespace FashionM.Movement
{
    public class clientMovement : MonoBehaviour
    {
        //private clientCollection CC;
        private NavMeshAgent agent;
        public Animator Anime;
        public Transform End;
        public GameObject ClientPosition;
        public GameObject PurchesUI;


        public bool reched = false;
        public bool Purchesed = false;
        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            //CC = GameObject.Find("Client Position").GetComponent<clientCollection>();
           /* if (ClientPosition == null)
                checkForEmetySlot();*/

            PurchesUI.SetActive(false);
        }

        void Update()
        {
            //checkForEmetySlot();
            moveTowardSlot();

            PurchesUI.transform.forward = Camera.main.transform.forward;

        }

        /*public void checkForEmetySlot()
        {
            if(ClientPosition == null && !reched)
            {
                foreach (Transform dc in CC.gameObject.transform)
                {
                    if (!dc.GetComponent<dottedCircle>().occupied && !dc.GetComponent<dottedCircle>().thisPositonIsMine)
                    {
                        ClientPosition = dc.gameObject;
                        
                    }
                }
            }

            if (ClientPosition != null && ClientPosition.GetComponent<dottedCircle>().occupied )
                ClientPosition = null;
        }*/


        public void moveTowardSlot()
        {
            if (ClientPosition != null && !transform.GetComponent<clientControl>().tredingComplete)
                agent.SetDestination(ClientPosition.transform.position);

            if (ClientPosition == null && !transform.GetComponent<clientControl>().tredingComplete)
                agent.SetDestination(transform.position);

            if (transform.GetComponent<clientControl>().tredingComplete)
                agent.SetDestination(End.position);

            Anime.SetFloat("speed", agent.velocity.magnitude);
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Slot"))
            {                
                if (agent.velocity.magnitude <= 0)
                {
                    reched = true;
                    PurchesUI.SetActive(true);

                }
            }
            if (transform.GetComponent<clientControl>().tredingComplete && other.gameObject.CompareTag("End"))
            {
                transform.GetComponent<clientControl>().tredingComplete = false;
                transform.GetComponent<clientControl>().startTreding = false;
                transform.GetComponent<clientControl>().coinSpwan = false;
                reched = false;
                Purchesed = false;
                PurchesUI.SetActive(false);
                transform.GetComponent<clientControl>().clientNeedItemRandomize();



            }
                
        }

        
    }

}
