using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Control;
namespace FashionM.Movement
{
    public class dottedCircle : MonoBehaviour
    {
        public bool occupied = false;
       /* public bool thisPositonIsMine = false;*/

        public float speed = 5;
        private float a;
        float C;
        private SpriteRenderer SR;
        private void Start()
        {
            SR = GetComponent<SpriteRenderer>();
            C = SR.color.a;
        }
        void Update()
        {
            a += speed * Time.deltaTime;            
            transform.rotation = Quaternion.Euler(90, a, 0);

            if (occupied)
            {
                if (C > 0)
                {
                    C -= Time.deltaTime;
                }
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, C);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Client"))
            {
                occupied = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            occupied = false;
            SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 1);
        }
    }
}
