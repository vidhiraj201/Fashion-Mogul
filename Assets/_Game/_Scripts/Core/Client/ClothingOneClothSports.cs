using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core
{
    public class ClothingOneClothSports : MonoBehaviour
    {
        public FashionM.Control.clientControl control;

        public GameObject DClothUp, DClothDown, Cloth0, Cloth1, Cloth2, Cloth3;

        private bool poof;

        private void Update()
        {
            ClothActive();
        }
        void ClothActive()
        {
            if (!control.clothTookFromEmpOrPlayer)
            {
                poof = false;
                x = 0.15f;
                if (control.NeedItem == control.lv.RackNumber0.RackNumber)
                {
                    if (DClothUp != null && DClothDown != null)
                    {
                        DClothUp.SetActive(true);
                        DClothDown.SetActive(true);
                    }

                    Cloth0.SetActive(false);
                    Cloth1.SetActive(false);
                    Cloth2.SetActive(false);
                    Cloth3.SetActive(false);
                }

                if (control.NeedItem == control.lv.RackNumber1.RackNumber)
                {
                    if (DClothUp != null && DClothDown != null)
                    {
                        DClothUp.SetActive(true);
                        DClothDown.SetActive(true);
                    }
                    Cloth0.SetActive(false);
                    Cloth1.SetActive(false);
                    Cloth2.SetActive(false);
                    Cloth3.SetActive(false);
                }
                if (control.NeedItem == control.lv.RackNumber2.RackNumber)
                {
                    if (DClothUp != null && DClothDown != null)
                    {
                        DClothUp.SetActive(true);
                        DClothDown.SetActive(false);
                    }
                    Cloth0.SetActive(false);
                    Cloth1.SetActive(false);
                    Cloth2.SetActive(false);
                    Cloth3.SetActive(true);
                }

                if (control.NeedItem == control.lv.RackNumber3.RackNumber)
                {
                    if (DClothUp != null && DClothDown != null)
                    {
                        DClothUp.SetActive(true);
                        DClothDown.SetActive(true);
                    }
                    Cloth0.SetActive(false);
                    Cloth1.SetActive(true);
                    Cloth2.SetActive(false);
                    Cloth3.SetActive(false);
                }
            }
            clothChange();
        }

        public ParticleSystem Poof;
        public Transform poofPos;
        float x = 0.15f;
        public void clothChange()
        {
            if (poof && x >= 0)
                x -= Time.deltaTime;
            if (control.tredingComplete)
            {
                if (!poof)
                {
                    GameObject poofObj = Instantiate(Poof.gameObject, poofPos.position, Quaternion.identity);
                    poofObj.transform.localScale = new Vector3(3, 3, 3);
                    poofObj.transform.parent = poofPos;
                    Destroy(poofObj, 1);
                    poof = true;
                }
                if (x <= 0)
                {
                    if (control.NeedItem == control.lv.RackNumber0.RackNumber)
                    {
                        if (DClothUp != null && DClothDown != null)
                        {
                            DClothUp.SetActive(false);
                            DClothDown.SetActive(true);
                        }
                        Cloth0.SetActive(true);
                        Cloth1.SetActive(false);
                        Cloth2.SetActive(false);
                        Cloth3.SetActive(false);
                    }

                    if (control.NeedItem == control.lv.RackNumber1.RackNumber)
                    {
                        if (DClothUp != null && DClothDown != null)
                        {
                            DClothUp.SetActive(true);
                            DClothDown.SetActive(true);
                        }
                        Cloth0.SetActive(false);
                        Cloth1.SetActive(true);
                        Cloth2.SetActive(false);
                        Cloth3.SetActive(false);

                    }
                    if (control.NeedItem == control.lv.RackNumber2.RackNumber)
                    {
                        if (DClothUp != null && DClothDown != null)
                        {
                            DClothUp.SetActive(true);
                            DClothDown.SetActive(false);
                        }
                        Cloth0.SetActive(false);
                        Cloth1.SetActive(false);
                        Cloth2.SetActive(true);
                        Cloth3.SetActive(true);
                    }

                    if (control.NeedItem == control.lv.RackNumber3.RackNumber)
                    {
                        if (DClothUp != null && DClothDown != null)
                        {
                            DClothUp.SetActive(true);
                            DClothDown.SetActive(false);
                        }
                        Cloth0.SetActive(false);
                        Cloth1.SetActive(true);
                        Cloth2.SetActive(false);
                        Cloth3.SetActive(true);
                    }
                }
            }


        }
    }
}
