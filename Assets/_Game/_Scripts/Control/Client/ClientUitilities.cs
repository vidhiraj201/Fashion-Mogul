using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Movement;

namespace FashionM.Control
{
    public class ClientUitilities : MonoBehaviour
    {
        public bool locked;
        

        public List<GameObject> empList = new List<GameObject>();
        public Transform EmpCol;
        void Start()
        {
            x = 0.7f;
            foreach (Transform emp in EmpCol)
            {
                if (!emp.GetComponent<empControl>().Occupied && !empList.Contains(emp.gameObject))
                {
                    empList.Add(emp.gameObject);
                }
            }
        }
        
        void FixedUpdate()
        {
            if (empList.Count >= 1)
            {
                if (!GetComponent<clientControl>().clothTookFromEmpOrPlayer && GetComponent<clientMovement>().reched && Target==null)
                {
                    checkForEmp();
                }
            }

            foreach (Transform emp in EmpCol)
            {
                if (!emp.GetComponent<empControl>().Occupied && !empList.Contains(emp.gameObject))
                {
                    empList.Add(emp.gameObject);
                }
            }

        }
        private void Update()
        {
            EmpMove();
        }

        public float x = 0.7f;
        public void EmpMove()
        {
            if (locked && GetComponent<clientMovement>().reched && !GetComponent<clientControl>().TradeComp && Target !=null)
            {
                if(Target.GetComponent<empMovement>().ClientNeedItem<=-1)
                    Target.GetComponent<empMovement>().isWalkingTowardClient = true;                
            }

            if (locked && GetComponent<clientControl>().clothTookFromEmpOrPlayer && Target !=null)
            {
                Target.GetComponent<empMovement>().agent.SetDestination(Target.transform.position);
                Target.GetComponent<empMovement>().isWalkingTowardClient = false;
                EMPRESET();

               /* if (x >= 0 && GetComponent<clientControl>().TradeComp)
                    x -= Time.deltaTime;

                if (x <= 0)
                {
                    x = 0;
                    EMPRESET();
                }*/
                
            }
        }



      public  void EMPRESET()
        {
            stopTrade();
            Target.GetComponent<empMovement>().isWalkingTowardClient = false;
            Target.GetComponent<empMovement>().gameObject.layer = 9;
            Target.GetComponent<empControl>().Occupied = false;
            Target.GetComponent<empControl>().StoreNumberStored = -1;
            Target.GetComponent<empMovement>().ClientNeedItem = -1;
            transform.gameObject.layer = 10;
            Target = null;
            locked = false;
        }

        private GameObject Target;

        public void stopTrade()
        {
            if (Target != null)
                Target.GetComponent<empControl>().TradeStarted = false;
            //FindObjectOfType<FashionM.Core.LevelManager>().CustomerIncrement += 1;
        }

        void checkForEmp()
        {

               /* for (int i = 0; i <= empList.Count - 1; i++)
                {
                    if (empList[i] != null && empList.Contains(empList[i]) && empList[i].GetComponent<empControl>().Occupied && Target != empList.Contains(empList[i]))
                    {
                        empList.Remove(empList[i]);
                    }
                    if (empList[i] == null)
                    {
                        empList.Remove(empList[i]);
                    }
                }*/

                if (empList.Count >= 1 && Target == null)
                {
                    int x = Random.Range(0, empList.Count);
                if (!empList[x].GetComponent<empControl>().Occupied)
                {
                    Target = empList[x];                
                }
                }

                if (Target != null)
                {
                    locked = true;
                if(!Target.GetComponent<empControl>().Occupied){
                    Target.GetComponent<empControl>().Occupied = true;
                    Target.GetComponent<empControl>().StoreNumberStored = -1;
                }
                
                    Target.GetComponent<empControl>().TargetForClient = transform.gameObject;
                    

                    if (!GetComponent<clientControl>().LeaveEmp && !GetComponent<clientControl>().clothTookFromEmpOrPlayer)
                {
                        Target.GetComponent<empMovement>().ClientNeedItem = GetComponent<clientControl>().NeedItem;
                    
                }

                    if (GetComponent<clientControl>().clothTookFromEmpOrPlayer && !GetComponent<clientControl>().LeaveEmp)
                {
                    Target.GetComponent<empMovement>().ClientNeedItem = -1;
                    Target.GetComponent<empControl>().StoreNumberStored = -1;
                }
                }
               // StartCoroutine(DelayInPickingNextEmployee(0.5f));
            }
        

        IEnumerator DelayInPickingNextEmployee(float t)
        {
            yield return new WaitForSeconds(t);
            
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
