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
        public float rotationSmooth = 0.01f;
        public float lookRotation = 90;

        public bool reched = false;
        public bool Purchesed = false;
        private float turnSmoothVelocity;

        public int num;
        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            PurchesUI.SetActive(false);
            num = Random.Range(0, 2);
            customerSetup();
        }

       
        void Update()
        {

            
            moveTowardSlot();

            PurchesUI.transform.forward = Camera.main.transform.forward;

            if(reched && !GetComponent<clientControl>().tredingComplete)
            {
                transform.rotation = Quaternion.Euler(0, lookRotation, 0);
            }
        }

        private void FixedUpdate()
        {
            customerSetup();
        }

        void customerSetup()
        {
            if (transform.GetChild(2).transform.GetChild(0).gameObject.activeSelf)
            {
                Anime = transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<Animator>();
            }
            if (transform.GetChild(2).transform.GetChild(1).gameObject.activeSelf)
            {
                Anime = transform.GetChild(2).transform.GetChild(1).gameObject.GetComponent<Animator>();
            }

            if (num == 0)
            {
                transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(false);
            }

            if (num == 1)
            {
                transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);

            }
        }


        public void moveTowardSlot()
        {

            if (agent.velocity.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(agent.velocity.x, agent.velocity.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSmooth);
                transform.rotation = Quaternion.Euler(0, angle, 0);
            }




            if (ClientPosition != null && !transform.GetComponent<clientControl>().tredingComplete && !transform.GetComponent<clientControl>().StopeWalking)
                agent.SetDestination(ClientPosition.transform.position);

            if (ClientPosition == null && !transform.GetComponent<clientControl>().tredingComplete || transform.GetComponent<clientControl>().StopeWalking)
                agent.SetDestination(transform.position);

            if (transform.GetComponent<clientControl>().TradeComp)
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
                transform.GetComponent<clientControl>().TradeComp = false;
                transform.GetComponent<clientControl>().startTreding = false;
                transform.GetComponent<clientControl>().coinSpwan = false;
                transform.GetComponent<clientControl>().CCountAdded = false;
                transform.GetComponent<ClientUitilities>().empList.Clear();
                transform.GetComponent<ClientUitilities>().x = 0.3f;
                reched = false;
                Purchesed = false;
                PurchesUI.SetActive(false);
                transform.GetComponent<clientControl>().clientNeedItemRandomize();
                transform.GetComponent<clientMovement>().Anime.ResetTrigger("Celeb");
                num = Random.Range(0, 2);
            }
                
        }

        private void OnTriggerExit(Collider other)
        {
            reched = false ;
        }

    }

}
