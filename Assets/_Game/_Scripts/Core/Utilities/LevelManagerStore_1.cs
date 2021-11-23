using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core
{
    public class LevelManagerStore_1 : MonoBehaviour
    {
        private GameManager gm;
        [Header("Store Objects")]
        public GameObject ObasicCloths;
        public GameObject OpremiumCloths;
        public GameObject OexclusiveBrand;
        public GameObject Ojewllry;

        [Header("Stores")]
        public bool basicCloths;
        public bool premiumCloths;
        public bool exclusiveBrand;
        public bool jewllry;
        void Start()
        {
            gm = FindObjectOfType<GameManager>();
        }

        void Update()
        {

        }
        void WatchOpen()
        {
        }
    }

}