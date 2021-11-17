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

        private Transform lastPos;
        private bool shoot;
        void Start()
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            Destroy(this.gameI mean Object, 3f);
        }

        private void Update()
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            if (shoot)
                transform.position = Vector3.MoveTowards(transform.position, lastPos.localPosition - new Vector3(0, 5, 0), DropSpeed * Time.deltaTime);
        }
        public void throwCloth(Transform obj)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            lastPos = obj;
            shoot = true;
 

            /*GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().mass = 1;
            GetComponent<ClothProjectile>().Launch = true;
            GetComponent<ClothProjectile>().shootPoint = obj;
*/
            transform.parent = null;

            if(Collector.GetComponent<playerStackingSystem>() != null)
                Collector.GetComponent<playerStackingSystem>().ClothObject.Remove(gameObject);

            if (Collector.GetComponent<EmpStackingSystem>() != null)
                Collector.GetComponent<EmpStackingSystem>().ClothObject.Remove(gameObject);
            //Destroy(gameObject, 1);
        }

    }
}
