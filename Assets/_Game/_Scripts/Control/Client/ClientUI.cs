using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FashionM.Control
{
    public class ClientUI : MonoBehaviour
    {
        public Image Cloth;
        public Transform UIHolder;
        public Vector3 HolderPositionOffset;

        public clientControl CC;

        // Start is called before the first frame update
        void Start()
        {
            UIHolder.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            ClothApply();
            //UIHolder.LookAt(Camera.main.transform.forward);
            UIHolder.forward = -Camera.main.transform.forward;

            if (CC.clothTookFromEmpOrPlayer)
                UIHolder.gameObject.SetActive(false);

            if(CC.CM.reched && !CC.clothTookFromEmpOrPlayer)
                UIHolder.gameObject.SetActive(true);

        }

        void ClothApply()
        {            
            if (CC.NeedItem == 0)
                Cloth.sprite = CC.lv.Rack_0;
            if (CC.NeedItem == 1)
                Cloth.sprite = CC.lv.Rack_1;
            if (CC.NeedItem == 2)
                Cloth.sprite = CC.lv.Rack_2;
            if (CC.NeedItem == 3)
                Cloth.sprite = CC.lv.Rack_3;
        }
    }
}
