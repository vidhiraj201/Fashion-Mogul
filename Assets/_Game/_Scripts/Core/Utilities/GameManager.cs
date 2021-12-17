﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace FashionM.Core
{
    public class GameManager : MonoBehaviour
    {
        public float CurrentCoin;
        public float dailyAmount;

        private dayCompleteReport watch;

        public Animator Cinemachine;

        public TextMeshProUGUI CoinCountText;
        public TextMeshProUGUI CustomerUI;
        public TextMeshProUGUI DayCountUI;
        public TextMeshProUGUI DayCountUI_1;


        public List<GameObject> Customer = new List<GameObject>();

        public List<GameObject> RightRoadFacingStations = new List<GameObject>();
        public List<GameObject> LeftRoadFacingStation = new List<GameObject>();
        public List<GameObject> LeftAndRightFacingStation = new List<GameObject>();
        public List<GameObject> NoRoadFacingStation = new List<GameObject>();

        public Material whileTutorial;

        public float MaxCoin;

        public float CountMultiplier;
        public float EmployeeCount;
        public float EmployeeAmount;

        public float customerGoal;
        public float TotalCustomerGoal;
        public float CustomerIn;
        public float CustomerOut;
        public float customerServed;

        [Header("UI")]
        public GameObject TapUI;
        public GameObject UnlockStoreExpansionUI;
        public GameObject HireEmployee;
        public GameObject dayCompleteUI;
        public GameObject dayStartUI;
        public GameObject InfintyUI;
        public Slider customerCountData; 

        [Header("Day Session")]
        public bool DayStart;
        public bool DayOff;
        public bool isTutorialOver;
        public bool isFinalTutorialOver;
        public bool day2TutorialOver;
        public bool ColorChanged;
        public bool ChangeTheColor;

        [Header("")]
        public GameObject Bound;
        public GameObject poofForColor;
        void Start()
        {
            customerGoalGenrator();
            if (!isTutorialOver)
                TapUI.SetActive(true);
            UnlockStoreExpansionUI.SetActive(false);
            HireEmployee.SetActive(false);
            dayCompleteUI.SetActive(false);
            //dayStartUI.SetActive(false);
            InfintyUI.SetActive(false);
            watch = FindObjectOfType<dayCompleteReport>();
        }

        bool x;
        void Update()
        {
            
            coinControl();
            DayCountUI.text = (dayCount + 1).ToString();
            
            if(dayCount>0)
                DayCountUI_1.text = (dayCount ).ToString();

            CustomerUI.text = customerServed + " / " + TotalCustomerGoal;
            customerCountData.maxValue = TotalCustomerGoal;
            customerCountData.value = customerServed;

            /*if (dayStartUI.activeSelf)
                dayStartUI.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Day " + (dayCount + 1);*/

          /*  if (dayCompleteUI.activeSelf)
            {
                dayCompleteUI.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Day " + (dayCount + 1);
                dayCompleteUI.transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = dailyAmount.ToString();
            }
*/
            /* if (Input.GetKeyDown(KeyCode.P))
             {
                 Instantiate(Employee, HD.position, Quaternion.identity).transform.parent = GameObject.Find("EmployeeCollection").transform;
             }*/

            if(!DayStart && !DayOff && !x && isTutorialOver)
            {
                StartCoroutine(StartGame(1.2f));
                x = true;
            }


            /*if (!DayStart)
            {
                try
                {
                    FindObjectOfType<playerStackingSystem>().resetStacking();
                    FindObjectOfType<EmpStackingSystem>().poofCloth();
                }
                catch
                {

                }
            }*/

        }


        void customerGoalGenrator()
        {
            if (dayCount <= 0 /*&& customerGoal <= 0*/ )
            {
                //customerGoal = 2;
                TotalCustomerGoal = 2;
            }
            if (dayCount == 1/* && customerGoal <= 0*/)
            {
                //customerGoal = 2;
                TotalCustomerGoal = 2;
            }
            if (dayCount == 2 /*&& customerGoal <= 0*/)
            {
                //customerGoal = 5;
                TotalCustomerGoal = 5;
            }
        }





        public void OnMouseDownData()
        {
                TapUI.SetActive(false);
        }

        void coinControl()
        {
            CurrentCoin = Mathf.Clamp(CurrentCoin, 0, MaxCoin);
            MaxCoin = Mathf.Clamp(MaxCoin, 0, Mathf.Infinity);


            CoinCountText.text = CurrentCoin.ToString("F0");

            if (MaxCoin > CurrentCoin)
                CurrentCoin += CountMultiplier;

            if (MaxCoin < CurrentCoin && MaxCoin>=0)
                CurrentCoin -= CountMultiplier;
        }

        public int dayCount;
        public void NextDayButton()
        {           
            dayCount += 1;
            DayOff = false;
            x = false;
            //StartCoroutine(startDayDelay(0.35f));
            customerServed -= TotalCustomerGoal;
            StartDayButton();
            dailyAmount = 0;
            if (dayCompleteUI.activeSelf)
                dayCompleteUI.transform.GetChild(0).GetComponent<Animator>().Play("Out");       
            if (dayCount >= 2 )
            {
                TotalCustomerGoal = TotalCustomerGoal * 2;
/*                customerGoal = TotalCustomerGoal;*/
            }            
            customerGoalGenrator();
            
        }

        public void StartDay()
        {
            StartCoroutine(FstTutorialOver(0.2f));
        }

        IEnumerator FstTutorialOver(float t)
        {
            FindObjectOfType<tutorialUI>().GetComponent<Animator>().Play("1");
            yield return new WaitForSeconds(t);
            isTutorialOver = true;
            DayStart = true;
        }
        IEnumerator startDayDelay(float t)
        {
            yield return new WaitForSeconds(t);
            /*try
            {
                FindObjectOfType<playerStackingSystem>().resetStacking();
                FindObjectOfType<EmpStackingSystem>().poofCloth();
            }
            catch
            {

            }*/
            //customerGoalGenrator();
            //DayStart = false;
            dailyAmount = 0;
            
        }

       public void StartDayButton()
        {
            //FindObjectOfType<FashionM.Movement.playerMovement>().isWalk = false;            

            DayStart = true;
            InfintyUI.SetActive(true);
        }

        IEnumerator StartGame(float t)
        {
            //dayStartUI.GetComponent<Animator>().Play("In");
            //FindObjectOfType<FashionM.Movement.playerMovement>().isWalk = true;
            yield return new WaitForSeconds(t);            
            //dayStartUI.GetComponent<Animator>().Play("Out");
            //FindObjectOfType<AnalyticalDataStorage>().dayStartData(dayCount, (int)customerGoal);
            
        }
    }
}
