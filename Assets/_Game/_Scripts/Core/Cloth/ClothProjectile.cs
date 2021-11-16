using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core
{
    public class ClothProjectile : MonoBehaviour
    {
        public Transform shootPoint;
        public bool Launch;

        private void Start()
        {

        }

        private void Update()
        {
            if (Launch)
                LaunchPorjectile();
        }
        Vector3 Vo;

        public void LaunchPorjectile()
        {
            Vo = CalculateVelocity(shootPoint.position - new Vector3(0, 5, 0), transform.position, 0.5f);
            GetComponent<Rigidbody>().velocity = Vo;
        }



        Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
        {
            Vector3 distance = target - origin;
            Vector3 distanceXZ = distance;
            distanceXZ.y = 0;

            float Sy = distance.y;
            float Sxz = distanceXZ.magnitude;

            float Vxz = Sxz / time;
            float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

            Vector3 result = distanceXZ.normalized;
            result *= Vxz;
            result.y = Vy;

            return result;
        }
    }
}
