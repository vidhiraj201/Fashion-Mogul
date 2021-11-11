using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Control
{
    public class ClientUitilities : MonoBehaviour
    {

        public int EmpNo;
        public bool locked;

        public List<GameObject> empList = new List<GameObject>();
        private Transform EmpCol;
        void Start()
        {
            EmpCol = GameObject.Find("EmployeeCollection").transform;
            foreach(Transform emp in EmpCol)
            {
                if (!emp.GetComponent<empControl>().Occupied)
                {
                    empList.Add(emp.gameObject);
                }
            }
        }
        
        void Update()
        {
            checkForEmp();
        }

        private GameObject Target;
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
            if (Target == null)
            {
                Target = empList[Random.Range(0, empList.Count)];
            }
            if (Target != null) {
                Target.GetComponent<empControl>().Occupied = true;
            }
        }
    }
}
