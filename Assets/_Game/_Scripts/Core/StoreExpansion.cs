using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FashionM.Core
{
   public class StoreExpansion : MonoBehaviour
    {
        public TextMeshPro StoreStatus;
        public TextMeshPro StoreUpgradesPrice;

        public float CoinReduceSpeed = 1;
        public float MaxCoinNeedToUnlock;

        public GameObject Bounds;
        private GameManager GM;

        // Start is called before the first frame update
        void Start()
        {
            GM = FindObjectOfType<GameManager>();
            StoreStatus.text = "Store Locked";
            StoreUpgradesPrice.text = "$" + MaxCoinNeedToUnlock;
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
        }
        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (GM.MaxCoin>=1 && MaxCoinNeedToUnlock >= 1)
                {
                    MaxCoinNeedToUnlock -= CoinReduceSpeed;
                    GM.MaxCoin -= CoinReduceSpeed;
                    StoreUpgradesPrice.text = "$" + MaxCoinNeedToUnlock;
                }
            }
        }
    }
}
