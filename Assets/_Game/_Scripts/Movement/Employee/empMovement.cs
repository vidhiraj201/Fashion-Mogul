using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FashionM.Control;

namespace FashionM.Movement
{
    public class empMovement : MonoBehaviour
    {

        private NavMeshAgent agent;
        [Header("Detection of Client")]
        public Animator Anime;
        [HideInInspector] public GameObject TargetToClient;
        [HideInInspector] public GameObject TargetToStore;
        public bool isWalkingTowardClient = false;
        public bool isWalkingTowardStore = false;
        public float rotationSmooth;

        

        private float turnSmoothVelocity;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
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

            if(GetComponent<empControl>().TargetForStore !=null)
                TargetToStore = GetComponent<empControl>().TargetForStore;


            if (isWalkingTowardClient)
                agent.SetDestination(TargetToClient.transform.position);

            if(isWalkingTowardStore)
                agent.SetDestination(TargetToStore.transform.position);

        }
    }
}
