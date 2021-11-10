using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FashionM.Core;


namespace FashionM.Control
{
    public class playerControl : MonoBehaviour        
    {

        private TextMeshPro Text;
        public int StoreNumberStored = 0;
        private GameManager manager;
        public Stores OR;

        private void Start()
        {
            Text = transform.GetChild(1).GetComponent<TextMeshPro>();
            manager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            if(StoreNumberStored>=1)
                Text.text = StoreNumberStored.ToString();

            if (StoreNumberStored <= 0)
                Text.text = "".ToString();

        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Client"))
            {
                if (other.gameObject.GetComponent<clientControl>().clientNeedItem == StoreNumberStored )
                {
                    other.gameObject.GetComponent<clientControl>().startTreding = true;
                    other.gameObject.GetComponent<clientControl>().playerIsNear = true;
                    /*if(other.gameObject.GetComponent<clientControl>().takeItemFromPlayer <= 0)
                        StoreNumberStored = 0;*/
                }
            }

            if (other.gameObject.CompareTag("Racks"))
            {
                OR = other.gameObject.GetComponent<Stores>();
                if (OR != null && !OR.isRackClosed)
                    OR.playerIsNear = true;               
            }

            if (other.gameObject.CompareTag("Coin"))
            {
                if(other.gameObject.GetComponent<Animator>() != null)
                {
                    other.gameObject.GetComponent<Animator>().SetTrigger("collect");
                    Destroy(other.gameObject.GetComponent<Collider>());
                    manager.MaxCoin += other.gameObject.GetComponent<DropCoin>().Coins;
                }
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Client"))
            {
                if (other.gameObject.GetComponent<clientControl>().clientNeedItem == StoreNumberStored)
                {
                    print("1");
                    if (other.gameObject.GetComponent<clientControl>().takeItemFromPlayer <= 0.1f)
                    {
                        print("2");
                        StoreNumberStored = 0;
                    }
                }
            }
        }
    }
}
