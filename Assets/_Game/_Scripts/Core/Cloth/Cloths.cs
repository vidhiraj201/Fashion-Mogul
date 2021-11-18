using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core {
    public class Cloths : MonoBehaviour
    {
        //public float Force;
        public float ClothIdentityNumber;
        public float DropSpeed;

        public GameObject Collector;
        public Transform DC;
        public LayerMask ClothMask;

        private Transform lastPos;
        private Rigidbody rb;

        private bool isTouched = false;
        private bool shoot;

        private Vector3 velocity;
        private float gravity;
        void Start()
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            DownCheck();
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            if (shoot)
            {
                transform.position = Vector3.MoveTowards(transform.position, lastPos.position - new Vector3(0, 5, 0), DropSpeed * Time.deltaTime);
                Destroy(this.gameObject, 1.5f);
            }
        }


        public void DownCheck()
        {
            if (!shoot)
            {
                isTouched = Physics.CheckSphere(DC.position, 0.01f, ClothMask);
                if (isTouched)
                    rb.isKinematic = true;

                if (!isTouched)
                    rb.isKinematic = false;
            }
           
        }

        public void throwCloth(Transform obj)
        {
            rb.isKinematic = true;
            lastPos = obj;
            shoot = true;
            transform.parent = null;

            if(Collector.GetComponent<playerStackingSystem>() != null)
                Collector.GetComponent<playerStackingSystem>().ClothObject.Remove(gameObject);

            if (Collector.GetComponent<EmpStackingSystem>() != null)
                Collector.GetComponent<EmpStackingSystem>().ClothObject.Remove(gameObject);
            //Destroy(gameObject, 1);
        }

    }
}
