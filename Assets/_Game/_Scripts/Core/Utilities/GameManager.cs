using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FashionM.Core
{
    public class GameManager : MonoBehaviour
    {
        private float CurrentCoin;
        private dayCompleteReport watch;

        public TextMeshProUGUI CoinCountText;
        public TextMeshProUGUI CustomerUI;
        public TextMeshProUGUI DayCountUI;


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
        public GameObject dayCompleteUI;
        public GameObject dayStartUI;
        public GameObject InfintyUI;


        public bool DayStart;
        public bool DayOff;

        void Start()
        {
            TapUI.SetActive(true);
            UnlockStoreExpansionUI.SetActive(false);
            HireEmployee.SetActive(false);
            dayCompleteUI.SetActive(false);
            dayStartUI.SetActive(false);
            InfintyUI.SetActive(false);
            watch = FindObjectOfType<dayCompleteReport>();
        }

        
        void Update()
        {
            coinControl();
            DayCountUI.text = "Day " + (dayCount + 1);
            CustomerUI.text = CustomerOut + " / " + customerGoal;


            if (dayStartUI.activeSelf)
                dayStartUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Day " + (dayCount + 1);

            if (dayCompleteUI.activeSelf)
            {
                dayCompleteUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Day " + (dayCount + 1);
                dayCompleteUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = MaxCoin.ToString();
            }

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

        public int dayCount;
        public void NextDayButton()
        {
            DayOff = false;
            StartCoroutine(startDayDelay(0.35f));            
            if (dayCompleteUI.activeSelf)
                dayCompleteUI.GetComponent<Animator>().Play("Out");

            CustomerIn = 0;
            CustomerOut = 0;
            customerGoal = customerGoal * 2;
            dayCount += 1;
        }


        IEnumerator startDayDelay(float t)
        {
            yield return new WaitForSeconds(t);
            DayStart = false;
        }

        public void StartDayButton()
        {
            DayStart = true;
            InfintyUI.SetActive(true);
            if (dayStartUI.activeSelf)
                dayStartUI.GetComponent<Animator>().Play("Out");
        }
    }
}
