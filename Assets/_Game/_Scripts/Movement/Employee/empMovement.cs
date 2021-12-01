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
        [HideInInspector] public AudioManager AM;
        public LevelManagerStore lv;
        [HideInInspector]public NavMeshAgent agent;
        public Animator Anime;

        [Header("Target Position")]
        public GameObject TargetToClient;
        public GameObject TargetToStore;

        [Header("Where to go")]
        public bool isWalkingTowardClient = false;
        public bool isWalkingTowardStore = false;

        [Header("What item you need")]
        public float ClientNeedItem;

        public float rotationSmooth;

        [HideInInspector] public Transform initPos;

        public bool Hold;

        private GameManager gm;

        private float turnSmoothVelocity;
        void Start()
        {
            ClientNeedItem = -1;
            agent = GetComponent<NavMeshAgent>();
            gm = FindObjectOfType<GameManager>();
            AM = FindObjectOfType<AudioManager>();
        }


        void Update()
        {
            moveAndRotateTowardsTarget();

            Anime.SetBool("hold", Hold);

            if (GetComponent<EmpStackingSystem>().ClothObject.Count > 0)
                Hold = true;
            if (GetComponent<EmpStackingSystem>().ClothObject.Count <= 0)
                Hold = false;
        }

        private void FixedUpdate()
        {
            movementTowardsTarget();
        }

        void moveAndRotateTowardsTarget()
        {
            
            if (agent.velocity.magnitude > 0.1f)
            {                
                float targetAngle = Mathf.Atan2(agent.velocity.x, agent.velocity.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSmooth);
                transform.rotation = Quaternion.Euler(0, angle, 0);
            }
            Anime.SetFloat("vertical", agent.velocity.magnitude);
        }

        void movementTowardsTarget()
        {

            if (GetComponent<empControl>().TargetForClient !=null)
                TargetToClient = GetComponent<empControl>().TargetForClient;

            if (isWalkingTowardClient)
                agent.SetDestination(TargetToClient.transform.position);

            if(isWalkingTowardStore)
                agent.SetDestination(TargetToStore.transform.position);

            if (!GetComponent<empControl>().Occupied)
            {
                agent.SetDestination(initPos.position);

            }

         /*   if()*/
         
            if (ClientNeedItem < 0 && GetComponent<empControl>().StoreNumberStored <= -1)
                return;

            if (ClientNeedItem == 0 && GetComponent<empControl>().StoreNumberStored <= -1 )
            {
                TargetToStore = lv.AiPosForRack0;
                isWalkingTowardStore = true;
            }

            if (ClientNeedItem == 1 && GetComponent<empControl>().StoreNumberStored <= -1)
            {
                TargetToStore = lv.AiPosForRack1;
                isWalkingTowardStore = true;
            }
            if (ClientNeedItem == 2 && GetComponent<empControl>().StoreNumberStored <= -1)
            {
                TargetToStore = lv.AiPosForRack2;
                isWalkingTowardStore = true;
            }
            if (ClientNeedItem == 3 && GetComponent<empControl>().StoreNumberStored <= -1)
            {
                TargetToStore = lv.AiPosForRack3;
                isWalkingTowardStore = true;
            }


        }

    }
}
