using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FashionM.Core
{
   public class StoreExpansion : MonoBehaviour
    {
        public TextMeshPro StoreStatus;
        public TextMeshPro StoreUpgradesPrice;

        public Image WaitTimerUnlockUI;
        public float WaitTimer=1;
        private float UIUnlock;
        private bool isPlayerNear;

        public float CoinReduceSpeed = 1;
        public float MaxCoinNeedToUnlock;
        public GameObject Bounds;

        private GameManager GM;

        
        public Vector3 PlacingPosition;

        // Start is called before the first frame update
        void Start()
        {
            GM = FindObjectOfType<GameManager>();
            StoreStatus.text = "Store Locked";
            StoreUpgradesPrice.text = "$" + MaxCoinNeedToUnlock;
            WaitTimerUnlockUI.gameObject.SetActive(false);
            UIUnlock = WaitTimer;
        }

        // Update is called once per frame
        void Update()
        {
            if (MaxCoinNeedToUnlock <= 0)
            {
                Bounds.transform.localScale = new Vector3(24,10,131);
                Bounds.transform.localPosition = new Vector3(-35.76f,39.3f,-36.45f);
                transform.GetComponent<MeshRenderer>().enabled = false;
                Destroy(this.gameObject);
            }
            OpenUI();
        }

        /*public void HitButton()
        {
            MaxCoinNeedToUnlock = 0;
        }*/

        public void OpenUI()
        {
            WaitTimerUnlockUI.transform.forward = -Camera.main.transform.forward;
            if (isPlayerNear)
            {
                UIUnlock -= Time.deltaTime;
                WaitTimerUnlockUI.gameObject.SetActive(true);
                WaitTimerUnlockUI.fillAmount = UIUnlock / WaitTimer;
                if (UIUnlock <= 0)
                {
                    isPlayerNear = false;
                    UIUnlock = WaitTimer;
                    WaitTimerUnlockUI.gameObject.SetActive(true);
                    GM.UnlockStoreExpansionUI.SetActive(true);
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isPlayerNear = true;
            }
        }
        private void OnCollisionStay(Collision collision)
        {

        }
        private void OnCollisionExit(Collision collision)
        {
            if (isPlayerNear)
            {
                isPlayerNear = false;
                WaitTimerUnlockUI.gameObject.SetActive(false);
                UIUnlock = WaitTimer;
            }
            if (GM.UnlockStoreExpansionUI.activeSelf)
                GM.UnlockStoreExpansionUI.GetComponent<Animator>().Play("Out");

        }
    }
}
