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
        public List<GameObject> Stations = new List<GameObject>();

        public float MaxCoin;

        public float customerGoal;
        public float CustomerIncrement;
        


        [Header("UI")]
        public GameObject TapUI;
        public GameObject UnlockStoreExpansionUI;
        public GameObject HireEmployee;
        public GameObject DayNightCycle;

        [Header("Store Objects")]
        public GameObject ObasicCloths;
        public GameObject OpremiumCloths;
        public GameObject OexclusiveBrand;
        public GameObject Ojewllry;

        public bool DayOff;

        [Header("Stores")]
        public bool basicCloths;
        public bool premiumCloths;
        public bool exclusiveBrand;
        public bool jewllry;

        [Header("Store Expansion")]
        public bool Ex1;
        public bool Ex2;
        public bool Ex3;
        public bool Ex4;

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
            CustomerIncrement = 0;
        }

    }
}
