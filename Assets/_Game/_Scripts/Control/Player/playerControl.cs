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
        public int RackNumberStored = 0;

        private GameManager manager;

        
        public Stores OR;
        private void Start()
        {
            Text = transform.GetChild(1).GetComponent<TextMeshPro>();
            manager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            if(RackNumberStored>=1)
                Text.text = RackNumberStored.ToString();

            if (RackNumberStored <= 0)
                Text.text = "".ToString();

        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Client"))
            {
                other.gameObject.GetComponent<clientControl>().startTreding = true;
                if (other.gameObject.GetComponent<clientControl>().clientNeedItem == RackNumberStored)
                {
                    other.gameObject.GetComponent<clientControl>().playerIsNear = true;
                    RackNumberStored = 0;
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
    }
}
