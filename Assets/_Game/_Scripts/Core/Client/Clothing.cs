using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core
{
    public class Clothing : MonoBehaviour
    {
        public FashionM.Control.clientControl control;

        public GameObject DClothUp,DClothDown, Cloth0, Cloth1, Cloth2, Cloth3;


        private void Update()
        {
            ClothActive();
        }
        void ClothActive()
        {
            if (!control.tredingComplete)
            {
                if(control.NeedItem == 0)
                {
                    DClothUp.SetActive(true);
                    DClothDown.SetActive(false);

                    Cloth0.SetActive(false);
                    Cloth1.SetActive(false);
                    Cloth2.SetActive(false);
                    Cloth3.SetActive(true);
                }

                if (control.NeedItem == 1)
                {
                    DClothUp.SetActive(true);
                    DClothDown.SetActive(false);

                    Cloth0.SetActive(false);
                    Cloth1.SetActive(false);
                    Cloth2.SetActive(false);
                    Cloth3.SetActive(true);
                }
                if (control.NeedItem == 2)
                {
                    DClothUp.SetActive(true);
                    DClothDown.SetActive(false);

                    Cloth0.SetActive(false);
                    Cloth1.SetActive(false);
                    Cloth2.SetActive(false);
                    Cloth3.SetActive(true);
                }

                if (control.NeedItem == 2)
                {
                    DClothUp.SetActive(false);
                    DClothDown.SetActive(true);

                    Cloth0.SetActive(false);
                    Cloth1.SetActive(true);
                    Cloth2.SetActive(false);
                    Cloth3.SetActive(false);
                }
            }

            if (control.tredingComplete)
            {
                if (control.NeedItem == 0)
                {
                    DClothUp.SetActive(false);
                    DClothDown.SetActive(false);

                    Cloth0.SetActive(true);
                    Cloth1.SetActive(false);
                    Cloth2.SetActive(false);
                    Cloth3.SetActive(true);
                }

                if (control.NeedItem == 1)
                {
                    DClothUp.SetActive(false);
                    DClothDown.SetActive(false);

                    Cloth0.SetActive(false);
                    Cloth1.SetActive(true);
                    Cloth2.SetActive(false);
                    Cloth3.SetActive(true);
                }
                if (control.NeedItem == 2)
                {
                    DClothUp.SetActive(false);
                    DClothDown.SetActive(false);

                    Cloth0.SetActive(false);
                    Cloth1.SetActive(false);
                    Cloth2.SetActive(true);
                    Cloth3.SetActive(true);
                }

                if (control.NeedItem == 2)
                {
                    DClothUp.SetActive(false);
                    DClothDown.SetActive(false);

                    Cloth0.SetActive(false);
                    Cloth1.SetActive(true);
                    Cloth2.SetActive(false);
                    Cloth3.SetActive(true);
                }
            }
        }

        public void clothChange()
        {

        }
    }
}
