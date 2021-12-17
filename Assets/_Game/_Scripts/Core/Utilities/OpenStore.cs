using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FashionM.Core {
    public class OpenStore : MonoBehaviour
    {
        private GameManager gm;
        private StoreExpansion sE;
        public int levelOpening;

        public string sectionName;
        // Start is called before the first frame update
        void Start()
        {
            sE = GetComponent<StoreExpansion>();
            gm = FindObjectOfType<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (sE.MaxCoinNeedToUnlock > 0 && gm.dayCount >= levelOpening)
            {
                print("Store Open");                
                gm.Cinemachine.Play(sectionName);
                StartCoroutine(delay(1f));
            }
        }


        IEnumerator delay(float t)
        {
            yield return new WaitForSeconds(t);
            sE.MaxCoinNeedToUnlock = 0;
        }
    }
}

