using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core
{
    public class tutorialUI : MonoBehaviour
    {
        GameManager gm;
        //int i = 1;
        public List<GameObject> StartCustomer = new List<GameObject>();
        public List<GameObject> Racks = new List<GameObject>();
        public GameObject particalEffect;
        public Transform aro;
        public GameObject DirectionalArrow;

        public void Awake()
        {
            GetComponent<Animator>().enabled = false;
        }

        public GameObject glow;
        void Start()
        {
            DirectionalArrow.SetActive(false);
            gm = FindObjectOfType<GameManager>();
            if (!gm.isTutorialOver)
            {
                GetComponent<Animator>().enabled = true;
                GetComponent<Animator>().Play("0");
            }
            aro = FindObjectOfType<FashionM.Control.playerControl>().Arrow;

            if (gm.dayCount == 1)
                glow.SetActive(false);
            //i = 1;
        }

        public bool reset;
        public bool reset_1;
        void Update()
        {
            if (StartCustomer.Count == 2 && num<=2 && !gm.isFinalTutorialOver && gm.dayCount==0)
            {
                newTutorialStart();
            }
            if (StartCustomer.Count == 2 && num <= 2 && !gm.day2TutorialOver && gm.dayCount == 1)
            {
                newTutorialStart_1();
            }
            if(gm.dayCount == 1 && !reset)
            {
                StartCustomer.Clear();
                DirectionalArrow.SetActive(false);                
                reset = true;
            }
            if (gm.dayCount == 1 && !reset_1 && StartCustomer.Count>0)
            {
                num = 0;
                reset_1 = true;
            }
        }
        int num = 0;
        [SerializeField]private GameObject Target;
        void newTutorialStart()
        {

            if (Target != null && StartCustomer.Count>0)
                DirectionalArrow.SetActive(true);

            if (FindObjectOfType<FashionM.Core.playerStackingSystem>().ClothObject.Count<=0 && num <2)
            {
                Target = Racks[0];
                DirectionalArrow.transform.LookAt(new Vector3(Target.transform.position.x,DirectionalArrow.transform.position.y,Target.transform.position.z));
            }
            if (num == 2 && !FindObjectOfType<FashionM.Control.playerControl>().particalExplod)
            {
                Destroy(Instantiate(particalEffect, aro.position, Quaternion.identity), 2);
                Destroy(aro.gameObject, 0.1f);
                FindObjectOfType<FashionM.Control.playerControl>().particalExplod = true;
                DirectionalArrow.SetActive(false);                
                Target = null;                
            }


            if (num==0 && FindObjectOfType<FashionM.Core.playerStackingSystem>().ClothObject.Count > 0)
            {
                Target = StartCustomer[0];
                DirectionalArrow.transform.LookAt(new Vector3(Target.transform.position.x, DirectionalArrow.transform.position.y, Target.transform.position.z));


            }

            if (num==1 && FindObjectOfType<FashionM.Core.playerStackingSystem>().ClothObject.Count > 0)
            {
                Target = StartCustomer[1];
                DirectionalArrow.transform.LookAt(new Vector3(Target.transform.position.x,DirectionalArrow.transform.position.y,Target.transform.position.z));
            }

            if(FindObjectOfType<playerStackingSystem>().ClothObject.Count >= 1  & StartCustomer.Count>0 && num<2 ) 
            {
                try
                {
                    if (Target != null && !Target.GetComponent<FashionM.Control.clientControl>().tredingComplete)
                    {
                        Target.transform.GetChild(2).gameObject.SetActive(true);
                    }
                }
                catch
                {

                }
               
            }

            if (FindObjectOfType<playerStackingSystem>().ClothObject.Count < 1 && num <2)
            {
                try
                {
                    if (Target != null && !Target.GetComponent<FashionM.Control.clientControl>().clothTookFromEmpOrPlayer)
                    {
                        if (Target.transform.GetChild(2).gameObject.activeSelf)
                            Target.transform.GetChild(2).gameObject.SetActive(false);
                    }
                }
                catch
                {

                }
                
            }

            if (StartCustomer[0].GetComponent<FashionM.Control.clientControl>().tredingComplete && !StartCustomer[0].GetComponent<FashionM.Control.clientControl>().particalExplod)
            {
                if (StartCustomer[0].transform.GetChild(2).gameObject.activeSelf)
                {
                    //Destroy(Instantiate(particalEffect, StartCustomer[0].transform.GetChild(2).transform.position, Quaternion.identity), 2);
                    StartCustomer[0].transform.GetChild(2).gameObject.SetActive(false);
                }
                
                StartCustomer[0].GetComponent<FashionM.Control.clientControl>().particalExplod = true;
                num++;
            }

            if (StartCustomer[1].GetComponent<FashionM.Control.clientControl>().tredingComplete && !StartCustomer[1].GetComponent<FashionM.Control.clientControl>().particalExplod)
            {
                if (StartCustomer[1].transform.GetChild(2).gameObject.activeSelf)
                {
                    //Destroy(Instantiate(particalEffect, StartCustomer[1].transform.GetChild(2).transform.position, Quaternion.identity), 2);
                    StartCustomer[1].transform.GetChild(2).gameObject.SetActive(false);
                }
                
                StartCustomer[1].GetComponent<FashionM.Control.clientControl>().particalExplod = true;
                //StartCustomer.Remove(StartCustomer[0]);
                num++;
            }
        }
        void newTutorialStart_1()
        {

            if (Target != null && StartCustomer.Count > 0)
                DirectionalArrow.SetActive(true);

            if (FindObjectOfType<FashionM.Core.playerStackingSystem>().ClothObject.Count <= 0 && num < 2)
            {
                Target = Racks[1];
                DirectionalArrow.transform.LookAt(new Vector3(Target.transform.position.x, DirectionalArrow.transform.position.y, Target.transform.position.z));
            }
            if (num == 2 /*&& !FindObjectOfType<FashionM.Control.playerControl>().particalExplod*/)
            {
                /*Destroy(Instantiate(particalEffect, aro.position, Quaternion.identity), 2);
                Destroy(aro.gameObject, 0.1f);
                FindObjectOfType<FashionM.Control.playerControl>().particalExplod = true;*/
                DirectionalArrow.SetActive(false);
                //num = 0;
            }


            if (num == 0 && FindObjectOfType<FashionM.Core.playerStackingSystem>().ClothObject.Count > 0)
            {
                try
                {
                    if(!StartCustomer[0].GetComponent<FashionM.Control.clientControl>().clothTookFromEmpOrPlayer)
                        Target = StartCustomer[0];
                }
                catch
                {
                    Target = StartCustomer[1];
                }

                DirectionalArrow.transform.LookAt(new Vector3(Target.transform.position.x, DirectionalArrow.transform.position.y, Target.transform.position.z));
            }

            if (num == 1 && FindObjectOfType<FashionM.Core.playerStackingSystem>().ClothObject.Count > 0)
            {
                try
                {
                    if (!StartCustomer[1].GetComponent<FashionM.Control.clientControl>().clothTookFromEmpOrPlayer)
                        Target = StartCustomer[1];
                }
                catch
                {
                    Target = StartCustomer[0];
                }
                DirectionalArrow.transform.LookAt(new Vector3(Target.transform.position.x, DirectionalArrow.transform.position.y, Target.transform.position.z));
            }

            if (FindObjectOfType<playerStackingSystem>().ClothObject.Count >= 1 & StartCustomer.Count > 0 && num < 2)
            {
                try
                {
                    if (Target != null && !Target.GetComponent<FashionM.Control.clientControl>().tredingComplete)
                    {
                        Target.transform.GetChild(2).gameObject.SetActive(true);
                    }
                }
                catch
                {

                }

            }

            if (FindObjectOfType<playerStackingSystem>().ClothObject.Count < 1 && num < 2)
            {
                try
                {
                    if (Target != null && !Target.GetComponent<FashionM.Control.clientControl>().clothTookFromEmpOrPlayer)
                    {
                        if (Target.transform.GetChild(2).gameObject.activeSelf)
                            Target.transform.GetChild(2).gameObject.SetActive(false);
                    }
                }
                catch
                {

                }

            }

            if (StartCustomer[0].GetComponent<FashionM.Control.clientControl>().tredingComplete && !StartCustomer[0].GetComponent<FashionM.Control.clientControl>().particalExplod)
            {
                if (StartCustomer[0].transform.GetChild(2).gameObject.activeSelf)
                {
                    //Destroy(Instantiate(particalEffect, StartCustomer[0].transform.GetChild(2).transform.position, Quaternion.identity), 2);
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
                    //Destroy(Instantiate(particalEffect, StartCustomer[1].transform.GetChild(2).transform.position, Quaternion.identity), 2);
                    Destroy(StartCustomer[1].transform.GetChild(2).gameObject, 0.1f);
                }
                DirectionalArrow.SetActive(false);
                StartCustomer[1].GetComponent<FashionM.Control.clientControl>().particalExplod = true;
                num++;
            }
        }
    }
}
