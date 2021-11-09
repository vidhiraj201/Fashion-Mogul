using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using FashionM.Movement;
using FashionM.Core;





namespace FashionM.Control
{
    public class clientControl : MonoBehaviour
    {
        public GameObject coin;
        public TextMeshPro T1;
        public Image waitTimerUI;
        public Transform UIHolder;



        public bool startTreding = false;
        public bool tredingComplete = false;  
        public int clientNeedItem;
        

        public float takeItemToPlayter;
        public float waitTimer = 1;
        public bool playerIsNear = false;

        [HideInInspector]public bool coinSpwan = false;
        private GameManager gm;
        private void Start()
        {
            takeItemToPlayter = waitTimer;
            waitTimerUI.gameObject.SetActive(false);
            gm = FindObjectOfType<GameManager>();
            clientNeedItemRandomize();
        }
        private void Update()
        {
            //waitTimerUI.transform.forward = Camera.main.transform.forward;
            UIHolder.forward = Camera.main.transform.forward;
            
            if (tredingComplete && !coinSpwan)
            {
                Instantiate(coin, new Vector3(transform.position.x,3.3f, transform.position.z), Quaternion.identity);
                coinSpwan = true;
            }

            T1.text = clientNeedItem.ToString();
            if (tredingComplete)
            {
                GetComponent<clientMovement>().PurchesUI.SetActive(false);
            }


            if (playerIsNear)
            {
                
                takeItemToPlayter -= Time.deltaTime;
                waitTimerUI.gameObject.SetActive(true);
                waitTimerUI.fillAmount = takeItemToPlayter / waitTimer;
                if (takeItemToPlayter <= 0)
                {
                    
                    waitTimerUI.gameObject.SetActive(false);
                    tredingComplete = true;
                    playerIsNear = false;
                    takeItemToPlayter = waitTimer;
                }
            }
        }

        public void clientNeedItemRandomize()
        {
            if (gm.basicCloths && !gm.premiumCloths && !gm.exclusiveBrand && !gm.jewllry)
            {
                clientNeedItem = 1;
            }

            if (gm.basicCloths && gm.premiumCloths && !gm.exclusiveBrand && !gm.jewllry)
            {
                clientNeedItem = Random.Range(1, 3);
            }
            if (gm.basicCloths && gm.premiumCloths && gm.exclusiveBrand && !gm.jewllry)
            {
                clientNeedItem = Random.Range(1, 4);
            }
            if (gm.basicCloths && gm.premiumCloths && gm.exclusiveBrand && gm.jewllry)
            {
                clientNeedItem = Random.Range(1, 5);
            }
        }

    }
}
