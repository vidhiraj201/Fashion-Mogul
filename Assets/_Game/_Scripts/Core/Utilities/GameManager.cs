using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FashionM.Core
{
    public class GameManager : MonoBehaviour
    {
        private float CurrentCoin;
        private Watch watch;

        public TextMeshProUGUI CoinCountText;
        public TextMeshProUGUI CustomerUI;
        public List<GameObject> RightRoadFacingStations = new List<GameObject>();
        public List<GameObject> LeftRoadFacingStation = new List<GameObject>();
        public List<GameObject> LeftAndRightFacingStation = new List<GameObject>();
        public List<GameObject> NoRoadFacingStation = new List<GameObject>();


        public float MaxCoin;

        public float EmployeeCount;

        public float customerGoal;
        public float CustomerIn;
        public float CustomerOut;

        [Header("UI")]
        public GameObject TapUI;
        public GameObject UnlockStoreExpansionUI;
        public GameObject HireEmployee;
        public GameObject DayNightCycle;
        

        public bool DayOff;

        void Start()
        {
            TapUI.SetActive(true);
            UnlockStoreExpansionUI.SetActive(false);
            HireEmployee.SetActive(false);
            DayNightCycle.SetActive(false);
            watch = FindObjectOfType<Watch>();
        }

        
        void Update()
        {
            coinControl();

            CustomerUI.text = CustomerOut + " / " + customerGoal;
           /* if (Input.GetKeyDown(KeyCode.P))
            {
                Instantiate(Employee, HD.position, Quaternion.identity).transform.parent = GameObject.Find("EmployeeCollection").transform;
            }*/
        }

        public void OnMouseDownData()
        {
                TapUI.SetActive(false);
        }

        void coinControl()
        {
            CoinCountText.text = CurrentCoin.ToString();

            if (MaxCoin > CurrentCoin)
                CurrentCoin += 1;
            if (MaxCoin < CurrentCoin)
                CurrentCoin -= 1;
        }

        public void NextDayButton()
        {
            DayOff = false;
            if (DayNightCycle.activeSelf)
                DayNightCycle.GetComponent<Animator>().Play("Out");

            CustomerIn = 0;
            CustomerOut = 0;
            customerGoal = customerGoal * 2;
        }

    }
}
