using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FashionM.Core {
    public class OpenStore : MonoBehaviour
    {
        private GameManager gm;
        private StoreExpansion sE;
        public int levelOpening;
        public GameObject SectionUnlockUI;
        public string sectionName;
        public bool isOpen;

        [Header("LevelUP")]
        public GameObject G1;
        public GameObject G2;
        public GameObject G3;
        // Start is called before the first frame update
        void Start()
        {
            sE = GetComponent<StoreExpansion>();
            gm = FindObjectOfType<GameManager>();

        }

        // Update is called once per frame
        void Update()
        {
            if (gm.dayCount == levelOpening - 1)
                SectionUnlockUI.SetActive(true);


            if (sE.MaxCoinNeedToUnlock <= 0 && !sE.enabled)
                isOpen = true;

            if (gm.dayCount >= levelOpening)
            {               
                sE.enabled = true;
                SectionUnlockUI.SetActive(false);

                if (!isOpen)
                {
                    G1.SetActive(false);
                    G3.SetActive(false);
                    G2.SetActive(true);
                    gm.Cinemachine.Play(sectionName);
                    try
                    {
                        FindObjectOfType<AnalyticalDataStorage>().StoreExpansionSentData(transform);
                    }
                    catch
                    {

                    }
                }

                StartCoroutine(delay(1f));
            }

            if(!G1.activeSelf && gm.dayCount != levelOpening)
            {
                cashDelay();
            }
        }

        [SerializeField]float x = 1.5f;
        void cashDelay()
        {
            if (x >= 0)
            {
                x -= Time.deltaTime;
            }
            if (x <= 0)
            {

                G1.SetActive(true);
                G2.SetActive(false);
                G3.SetActive(true);
            }
        }
        IEnumerator delay(float t)
        {
            yield return new WaitForSeconds(t);

            isOpen = true;
            G2.SetActive(false);
            if (sE.MaxCoinNeedToUnlock > 0)
                sE.MaxCoinNeedToUnlock = 0;
        }
    }
}

