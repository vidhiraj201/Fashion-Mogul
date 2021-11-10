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


        [Header("UI")]
        public GameObject TapUI;
        public GameObject UnlockStoreUI;
        public GameObject HireEmployee;

        [Header("Stores")]
        public bool basicCloths;
        public bool premiumCloths;
        public bool exclusiveBrand;
        public bool jewllry;


        void Start()
        {
            TapUI.SetActive(true);
            UnlockStoreUI.SetActive(false);
            HireEmployee.SetActive(false);
        }

        
        void Update()
        {
            coinControl();
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
