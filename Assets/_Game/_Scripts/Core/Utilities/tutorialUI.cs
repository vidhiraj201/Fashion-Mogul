using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core
{
    public class tutorialUI : MonoBehaviour
    {
        GameManager gm;
        int i = 0;
        public List<GameObject> StartCustomer = new List<GameObject>();
        void Start()
        {
            gm = FindObjectOfType<GameManager>();
            GetComponent<Animator>().Play(i.ToString());
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !gm.isTutorialOver && i<=3)
            {
                i ++;
                GetComponent<Animator>().Play(i.ToString());
            }
            if (i == 3)
                gm.isTutorialOver = true;
        }
    }
}
