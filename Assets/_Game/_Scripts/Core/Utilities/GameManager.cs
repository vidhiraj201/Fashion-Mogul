using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FashionM.Core
{
    public class GameManager : MonoBehaviour
    {
        public float MaxCoin;
        private float CurrentCoin;
        public TextMeshProUGUI CoinCountText;


        [Header("Store Objects")]
        public GameObject ObasicCloths;
        public GameObject OpremiumCloths;
        public GameObject OexclusiveBrand;
        public GameObject Ojewllry;



        public List<GameObject> Stations = new List<GameObject>();

        public bool DayOff;

        [Header("UI")]
        public GameObject TapUI;
        public GameObject UnlockStoreExpansionUI;
        public GameObject HireEmployee;

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


        /*
                [Header("TestDummy")]
                public GameObject Employee;
                public Transform HD;

        */
        void Start()
        {
            TapUI.SetActive(true);
            UnlockStoreExpansionUI.SetActive(false);
            HireEmployee.SetActive(false);
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


    }
}
