using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FashionM.Core
{
    public class Station : MonoBehaviour
    {
        public LevelManagerStore lv;
        public GameObject clientPosition;
        public GameObject NewClients;       

        //public TextMeshPro StationStatus;
        public TextMeshPro StationPrice;

        public float CoinReduceSpeed = 1;
        public float MaxCoinNeedToUnlock;

        private GameManager GM;


        /*private float unlockStation;

        private bool PlayerIsOnStation = false;
        private bool isStationOpen = false;*/


        private void Start()
        {
            GM = FindObjectOfType<GameManager>();
            //StationStatus.text = "Station Locked";
            StationPrice.text = "$" + MaxCoinNeedToUnlock;
        }
        void Update()
        {
            if (MaxCoinNeedToUnlock <= 0)
            {
                FindObjectOfType<AudioManager>().source.PlayOneShot(FindObjectOfType<AudioManager>().MoneyCounting, 0.5f);
                transform.GetComponent<MeshRenderer>().enabled = false;
                clientPosition.SetActive(true);
                NewClients.SetActive(true);
                Destroy(this.gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            /*if (collision.gameObject.CompareTag("Player"))*/
                //PlayerIsOnStation = true;
        }
        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if(lv.rackOpen.Count>0)
                {
                    if (GM.MaxCoin >= MaxCoinNeedToUnlock && MaxCoinNeedToUnlock >= 0)
                    {
                        MaxCoinNeedToUnlock -= CoinReduceSpeed*5;
                        GM.MaxCoin -= CoinReduceSpeed*5;
                        StationPrice.text = "$" + MaxCoinNeedToUnlock;
                    }
                }
                
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            //PlayerIsOnStation = false;
        }
    }
}
