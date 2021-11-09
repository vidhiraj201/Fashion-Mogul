using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Control
{
    public class clientCollection : MonoBehaviour
    {
        public GameObject client;
        public List<GameObject> ClientPosition = new List<GameObject>();

        private void Awake()
        {
            foreach(Transform obj in transform)
            {
                ClientPosition.Add(obj.gameObject);
            }
        }

        private void Update()
        {

        }

        public void spwanClient()
        {

        }

    }

}