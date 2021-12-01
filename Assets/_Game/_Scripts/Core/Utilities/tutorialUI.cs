using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core
{
    public class tutorialUI : MonoBehaviour
    {
        GameManager gm;
        int i = 1;
        public List<GameObject> StartCustomer = new List<GameObject>();
        public GameObject particalEffect;
        public Transform aro;
        void Start()
        {
            gm = FindObjectOfType<GameManager>();
            GetComponent<Animator>().Play("0");
            aro = FindObjectOfType<FashionM.Control.playerControl>().Arrow;
            i = 1;
        }

        void Update()
        {
            if (StartCustomer.Count == 2 && num<=2)
            {
                newTutorialStart();
            }
            if (Input.GetMouseButtonDown(0) && !gm.isTutorialOver && i<=2)

            {
                i ++;
                GetComponent<Animator>().Play(i.ToString());
            }


        }
        int num = 0;
        private GameObject Target;
        void newTutorialStart()
        {

               if (num==2 && !FindObjectOfType<FashionM.Control.playerControl>().particalExplod)
                {
                    Destroy(Instantiate(particalEffect, aro.position, Quaternion.identity), 2);
                    Destroy(aro.gameObject,0.1f);
                    FindObjectOfType<FashionM.Control.playerControl>().particalExplod = true;
                }            



            if (num==0 )
            {
                Target = StartCustomer[0];
            }

            if (num==1)
            {
                Target = StartCustomer[1];
            }

            if(FindObjectOfType<playerStackingSystem>().ClothObject.Count >= 1  & StartCustomer.Count>0 && num<2) 
            {
                if (Target != null && !Target.GetComponent<FashionM.Control.clientControl>().tredingComplete)
                {
                    Target.transform.GetChild(2).gameObject.SetActive(true);
                }
            }
            if (FindObjectOfType<playerStackingSystem>().ClothObject.Count < 1 && num <2)
            {
                if (Target != null && !Target.GetComponent<FashionM.Control.clientControl>().clothTookFromEmpOrPlayer)
                {
                    if(Target.transform.GetChild(2).gameObject.activeSelf)
                        Target.transform.GetChild(2).gameObject.SetActive(false);
                }
            }

           /* if (Target!=null && Target.GetComponent<FashionM.Control.clientControl>().tredingComplete && !Target.GetComponent<FashionM.Control.clientControl>().particalExplod)
            {
                Destroy(Instantiate(particalEffect, Target.transform.GetChild(2).transform.position, Quaternion.identity), 2);
                Destroy(Target.transform.GetChild(2).gameObject, 0.1f);
                Target.GetComponent<FashionM.Control.clientControl>().particalExplod = true;
                StartCustomer.Remove(Target);
                num++;

            }*/


            if (StartCustomer[0].GetComponent<FashionM.Control.clientControl>().tredingComplete && !StartCustomer[0].GetComponent<FashionM.Control.clientControl>().particalExplod)
            {
                if (StartCustomer[0].transform.GetChild(2).gameObject.activeSelf)
                {
                    Destroy(Instantiate(particalEffect, StartCustomer[0].transform.GetChild(2).transform.position, Quaternion.identity), 2);
                    Destroy(StartCustomer[0].transform.GetChild(2).gameObject, 0.1f);
                }
                
                StartCustomer[0].GetComponent<FashionM.Control.clientControl>().particalExplod = true;
                //StartCustomer.Remove(StartCustomer[0]);
                num++;
            }

            if (StartCustomer[1].GetComponent<FashionM.Control.clientControl>().tredingComplete && !StartCustomer[1].GetComponent<FashionM.Control.clientControl>().particalExplod)
            {
                if (StartCustomer[1].transform.GetChild(2).gameObject.activeSelf)
                {
                    Destroy(Instantiate(particalEffect, StartCustomer[1].transform.GetChild(2).transform.position, Quaternion.identity), 2);
                    Destroy(StartCustomer[1].transform.GetChild(2).gameObject, 0.1f);
                }
                
                StartCustomer[1].GetComponent<FashionM.Control.clientControl>().particalExplod = true;
                //StartCustomer.Remove(StartCustomer[0]);
                num++;
            }
        }
    }
}
