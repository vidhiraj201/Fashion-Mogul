using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core
{
    public class DropCoin : MonoBehaviour
    {
        public float force;
        public float Coins = 100;
        private bool StoreToPlayer;

        public void detatachFromClient()
        {
            transform.parent = null;
        }
        public void Destroy()
        {
            Destroy(this.gameObject);
        }

        void Start()
        {
            transform.rotation = Random.rotation;
            GetComponent<Rigidbody>().AddForce(transform.up * force, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(transform.forward * (force), ForceMode.Impulse);
        }

        private void Update()
        {
            if (StoreToPlayer)
            {
                transform.GetComponent<Collider>().enabled = false;
                transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0,05,0), 50 * Time.deltaTime);
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                GetComponent<Rigidbody>().isKinematic = true;
            }
            if (collision.gameObject.CompareTag("Player") && !GetComponent<Rigidbody>().isKinematic)
            {
                StoreToPlayer = true;
                GetComponent<Rigidbody>().isKinematic = true;
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().MaxCoin += Coins;
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().dailyAmount += Coins;
                Destroy(this.gameObject, 0.15f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && GetComponent<Rigidbody>().isKinematic)
            {
                StoreToPlayer = true;
                GetComponent<Rigidbody>().isKinematic = true;
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().MaxCoin += Coins;
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().dailyAmount += Coins;
                Destroy(this.gameObject, 0.15f);
            }
        }

    }
}
