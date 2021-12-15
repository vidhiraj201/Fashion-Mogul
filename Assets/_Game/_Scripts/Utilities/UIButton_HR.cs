using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FashionM.Control;

namespace FashionM.Core 
{
    public class UIButton_HR : MonoBehaviour
    {

        public TextMeshProUGUI BAmount;
        public TextMeshProUGUI EmpCountUI;
        /*public float EmployeeAmount;*/
        public float EmployeeAmountMulti;
        public GameObject Employee;

        private TextMeshProUGUI BName;
        private GameManager gm;
        private Image BUI;

        // Start is called before the first frame update
        void Start()
        {
            gm = FindObjectOfType<GameManager>();
            BUI = GetComponent<Image>();
            BName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            ButtonUpdate();
            EmpCountUI.text = gm.EmployeeCount.ToString();
        }

        void ButtonUpdate()
        {
            BAmount.text = gm.EmployeeAmount.ToString("F0");

            if (gm.MaxCoin >= gm.EmployeeAmount)
            {
                BUI.color = new Color32(255, 255, 255, 255);
                BName.color = new Color32(255, 255, 255, 255);
                BAmount.color = new Color32(0, 0, 0, 255);
                transform.GetComponent<Button>().enabled = true;
            }

            if (gm.MaxCoin < gm.EmployeeAmount)
            {
                BUI.color = new Color32(202, 202, 202, 130);
                BName.color = new Color32(255, 255, 255, 255);
                BAmount.color = new Color32(0, 0, 0, 200);
                transform.GetComponent<Button>().enabled = false;
            }
        }
        public void hireEmployee()
        {
            if(gm.MaxCoin >= gm.EmployeeAmount)
            {
                
                FindObjectOfType<AudioManager>().source.PlayOneShot(FindObjectOfType<AudioManager>().MoneyCounting, 0.5f);
                GameObject EMP =  Instantiate(Employee, FindObjectOfType<playerControl>().HR.SpwanPoint.position, Quaternion.identity);
                EMP.transform.parent = FindObjectOfType<playerControl>().HR.Collection;
                EMP.GetComponent<FashionM.Movement.empMovement>().lv = FindObjectOfType<playerControl>().HR.LevelManager;                
                EMP.GetComponent<FashionM.Movement.empMovement>().initPos = FindObjectOfType<playerControl>().HR.SpwanPoint;                
                gm.HireEmployee.GetComponent<Animator>().Play("Out");
                gm.MaxCoin -= gm.EmployeeAmount;
                gm.EmployeeAmount = gm.EmployeeAmount * EmployeeAmountMulti;
                gm.EmployeeCount += 1;
                FindObjectOfType<AnalyticalDataStorage>().EmployeeHire((int)gm.EmployeeCount);
            }
        }

        public void closeUI()
        {
            if (gm.HireEmployee.activeSelf)
                gm.HireEmployee.GetComponent<Animator>().Play("Out");
        }
    }
}
