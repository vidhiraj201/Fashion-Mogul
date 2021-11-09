using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Movement
{
    public class dottedCircle : MonoBehaviour
    {
        public bool occupied = false;
        public bool thisPositonIsMine = false;

        public float speed = 5;
        private float a;
        void Update()
        {
            a += speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(90, a, 0);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                /*print("it's Player Do somthing");*/
            }
        }

        private void OnTriggerExit(Collider other)
        {
            occupied = false;
        }
    }
}
