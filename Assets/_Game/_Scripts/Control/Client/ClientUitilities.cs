﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Movement;

namespace FashionM.Control
{
    public class ClientUitilities : MonoBehaviour
    {
        public bool locked;
        

        public List<GameObject> empList = new List<GameObject>();
        private Transform EmpCol;
        void Start()
        {
            EmpCol = GameObject.Find("EmployeeCollection").transform;
        }
        
        void FixedUpdate()
        {
            if(!GetComponent<clientControl>().tredingComplete && GetComponent<clientMovement>().reched)
                checkForEmp();
        }
        private void Update()
        {
            EmpMove();
        }

        public void EmpMove()
        {
            if (locked && GetComponent<clientMovement>().reched )
            {
                if(Target.GetComponent<empMovement>().ClientNeedItem<=0)
                    Target.GetComponent<empMovement>().isWalkingTowardClient = true;                
            }

            if (locked && GetComponent<clientControl>().tredingComplete)
            {
                stopTrade();
                Target.GetComponent<empMovement>().isWalkingTowardClient = false;
                Target.GetComponent<empMovement>().gameObject.layer = 9;
                Target.GetComponent<empControl>().Occupied = false;
                Target.GetComponent<empMovement>().ClientNeedItem = 0;
                /*transform.GetComponent<clientControl>().NeedItem = 0;*/
                transform.gameObject.layer = 10;
                Target = null;
                locked = false;
            }
        }



        private GameObject Target;

        public void stopTrade()
        {
            if (Target != null)
                Target.GetComponent<empControl>().TradeStarted = false;
        }

        void checkForEmp()
        {
            foreach (Transform emp in EmpCol)
            {
                if (!emp.GetComponent<empControl>().Occupied && !empList.Contains(emp.gameObject))
                {
                    empList.Add(emp.gameObject);
                }
            }

            for (int i = 0; i <= empList.Count - 1; i++)
            {
                if (empList[i] != null && empList.Contains(empList[i]) && empList[i].GetComponent<empControl>().Occupied && Target != empList.Contains(empList[i]))
                {
                    empList.Remove(empList[i]);
                }
                if (empList[i] == null)
                {
                    empList.Remove(empList[i]);
                }
            }
            if (Target == null && empList.Count > 0)
            {
                Target = empList[Random.Range(0, empList.Count)];                
            }
            if (Target != null)
            {
                locked = true;
                Target.GetComponent<empControl>().Occupied = true;
                Target.GetComponent<empControl>().TargetForClient = transform.gameObject;
            }

            

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Emp"))
            {
                transform.gameObject.layer = 12;   
            }
        }
    }
}
