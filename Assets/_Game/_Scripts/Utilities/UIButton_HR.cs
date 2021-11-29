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
        public float EmployeeAmount;
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
            BAmount.text = EmployeeAmount.ToString();

            if (gm.MaxCoin >= EmployeeAmount)
            {
                BUI.color = new Color32(255, 255, 255, 255);
                BName.color = new Color32(255, 255, 255, 255);
                BAmount.color = new Color32(255, 255, 255, 255);
                transform.GetComponent<Button>().enabled = true;
            }

            if (gm.MaxCoin < EmployeeAmount)
            {
                BUI.color = new Color32(202, 202, 202, 160);
                BName.color = new Color32(202, 202, 202, 160);
                BAmount.color = new Color32(202, 202, 202, 160);
                transform.GetComponent<Button>().enabled = false;
            }
        }
        public void hireEmployee()
        {
            if(gm.MaxCoin >= EmployeeAmount)
            {
                FindObjectOfType<AudioManager>().source.PlayOneShot(FindObjectOfType<AudioManager>().MoneyCounting, 0.5f);
                GameObject EMP =  Instantiate(Employee, FindObjectOfType<playerControl>().HR.SpwanPoint.position, Quaternion.identity);
                EMP.transform.parent = FindObjectOfType<playerControl>().HR.Collection;
                EMP.GetComponent<FashionM.Movement.empMovement>().lv = FindObjectOfType<playerControl>().HR.LevelManager;                
                EMP.GetComponent<FashionM.Movement.empMovement>().initPos = FindObjectOfType<playerControl>().HR.SpwanPoint;                
                gm.HireEmployee.GetComponent<Animator>().Play("Out");
                gm.MaxCoin -= EmployeeAmount;
                EmployeeAmount += 200;
                gm.EmployeeCount += 1;
            }
        }

    }
}
