using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FashionM.Control;
using FashionM.Core;

namespace FashionM.Movement
{
    public class empMovement : MonoBehaviour
    {

        private NavMeshAgent agent;
        [Header("Detection of Client")]
        public Animator Anime;
        public GameObject TargetToClient;
        public GameObject TargetToStore;
        public bool isWalkingTowardClient = false;
        public bool isWalkingTowardStore = false;
        public float ClientNeedItem;
        public float rotationSmooth;

        private GameManager gm;

        private float turnSmoothVelocity;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            gm = FindObjectOfType<GameManager>();
        }


        void Update()
        {
            moveAndRotateTowardsTarget();
        }

        void moveAndRotateTowardsTarget()
        {
            movementTowardsTarget();
            if (agent.velocity.magnitude > 0.1f)
            {
                
                float targetAngle = Mathf.Atan2(agent.velocity.x, agent.velocity.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSmooth);
                transform.rotation = Quaternion.Euler(0, angle, 0);
            }
            Anime.SetFloat("speed", agent.velocity.magnitude);
        }

        void movementTowardsTarget()
        {

            if (GetComponent<empControl>().TargetForClient !=null)
                TargetToClient = GetComponent<empControl>().TargetForClient;

            if (isWalkingTowardClient)
                agent.SetDestination(TargetToClient.transform.position);

            if(isWalkingTowardStore)
                agent.SetDestination(TargetToStore.transform.position);

           if(GetComponent<empControl>().StoreNumberStored <= 0)
            {
                if (ClientNeedItem <= 0)
                    return;
                if (ClientNeedItem == 1)
                {
                    TargetToStore = gm.ObasicCloths;
                    isWalkingTowardStore = true;
                }
                if (ClientNeedItem == 2)
                {
                    TargetToStore = gm.OpremiumCloths;
                    isWalkingTowardStore = true;
                }
                if (ClientNeedItem == 3)
                {
                    TargetToStore = gm.OexclusiveBrand;
                    isWalkingTowardStore = true;
                }
                if (ClientNeedItem == 4)
                {
                    TargetToStore = gm.Ojewllry;
                    isWalkingTowardStore = true;
                }
            }
        }
    }
}
