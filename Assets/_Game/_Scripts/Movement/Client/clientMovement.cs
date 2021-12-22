﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FashionM.Control;

namespace FashionM.Movement
{
    public class clientMovement : MonoBehaviour
    {
        //private clientCollection CC;
        private FashionM.Core.GameManager gm;
        private NavMeshAgent agent;

        public Animator Anime;
        public GameObject ClientPosition;
        //public GameObject PurchesUI;
        public float rotationSmooth = 0.01f;
        public float lookRotation = 90;

        public bool reched = false;
        public bool Purchesed = false;
        private float turnSmoothVelocity;

        public int num;
        // Start is called before the first frame update
        void Start()
        {
            gm = FindObjectOfType<FashionM.Core.GameManager>();
            agent = GetComponent<NavMeshAgent>();
            //PurchesUI.SetActive(false);
            num = 0;
            customerSetup();
        }


        float x = 180;
        float xDelay = 0.2f;
        void Update()
        {

            
            moveTowardSlot();

            if (reched && !GetComponent<clientControl>().startTreding)
            {
                gameObject.layer = 10;
                GetComponent<clientControl>().startTreding = true;
            }
            //PurchesUI.transform.forward = -Camera.main.transform.forward;
            //PurchesUI.transform.LookAt(Camera.main.transform.position);

            if (reched && !GetComponent<clientControl>().clothTookFromEmpOrPlayer)
            {
                transform.rotation = Quaternion.Euler(0, lookRotation, 0);
            }
            if(GetComponent<clientControl>().tredingComplete && !GetComponent<clientControl>().TradeComp && x>=0 && xDelay>0)
            {
                xDelay -= Time.deltaTime;
                if (xDelay <= 0)
                {
                    xDelay = 0;
                    x -= 10;
                    transform.rotation = Quaternion.Euler(0, x, 0);
                }
                
            }
        }

        private void FixedUpdate()
        {
            customerSetup();
        }

        void customerSetup()
        {
            if (transform.GetChild(1).transform.GetChild(0).gameObject.activeSelf)
            {
                Anime = transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Animator>();
            }

            if (transform.GetChild(1).transform.GetChild(1).gameObject.activeSelf)
            {
                Anime = transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<Animator>();
            }

            if (num == 0)
            {
                transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
            }

            if (num == 1)
            {
                transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);

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




            if (ClientPosition != null && !transform.GetComponent<clientControl>().clothTookFromEmpOrPlayer && !transform.GetComponent<clientControl>().StopWalking && gm.DayStart)
                agent.SetDestination(ClientPosition.transform.position);

            if (ClientPosition == null && !transform.GetComponent<clientControl>().clothTookFromEmpOrPlayer || transform.GetComponent<clientControl>().StopWalking || !gm.DayStart)
                agent.SetDestination(transform.position);

            if (transform.GetComponent<clientControl>().TradeComp || transform.GetComponent<clientControl>().StopWalking)
                agent.SetDestination(GetComponent<clientControl>().lv.END.position);

            Anime.SetFloat("speed", agent.velocity.magnitude);
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Slot"))
            {                
                if (agent.velocity.magnitude <= 0)
                {
                    reched = true;
                    //PurchesUI.SetActive(true);

                }
            }
            if (transform.GetComponent<clientControl>().clothTookFromEmpOrPlayer && other.gameObject.CompareTag("End"))
            {
                gameObject.layer = 10;

/*                if (!transform.GetComponent<clientControl>().lv.Customers.Contains(this.gameObject))
                    transform.GetComponent<clientControl>().lv.Customers.Add(this.gameObject);*/
                
                transform.GetComponent<clientControl>().clothTookFromEmpOrPlayer = false;                
                transform.GetComponent<clientControl>().particalExplod = false;                
                transform.GetComponent<clientControl>().LeaveEmp = false;
                transform.GetComponent<clientControl>().tredingComplete = false;
                transform.GetComponent<clientControl>().TradeComp = false;
                transform.GetComponent<clientControl>().startTreding = false;
                transform.GetComponent<clientControl>().coinSpwan = false;
                transform.GetComponent<clientControl>().CCountAdded = false;
                transform.GetComponent<clientControl>().t = 0.5f;
                transform.GetComponent<ClientUitilities>().empList.Clear();
                transform.GetComponent<ClientUitilities>().x = 0.7f;
                reched = false;
                Purchesed = false;
                transform.GetComponent<clientControl>().clientNeedItemRandomize();
                transform.GetComponent<clientMovement>().Anime.ResetTrigger("Celeb");
                num = 0;
            }
                
        }

        private void OnTriggerExit(Collider other)
        {
            reched = false ;
        }

    }

}
