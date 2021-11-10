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
        public float EmployeeAmount;
        public GameObject Employee;

        private TextMeshProUGUI BName;
        private GameManager gm;
        private HRDesk HD;
        private Image BUI;

        // Start is called before the first frame update
        void Start()
        {
            gm = FindObjectOfType<GameManager>();
            HD = FindObjectOfType<HRDesk>();
            BUI = GetComponent<Image>();
            BName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            ButtonUpdate();
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
                Instantiate(Employee, HD.SpwanPoint.position, Quaternion.identity);
                gm.HireEmployee.GetComponent<Animator>().Play("Out");
                gm.MaxCoin -= EmployeeAmount;
            }
        }

    }
}
