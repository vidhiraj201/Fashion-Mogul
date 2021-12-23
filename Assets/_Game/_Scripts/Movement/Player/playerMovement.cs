using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;

namespace FashionM.Movement
{
    public class playerMovement : MonoBehaviour
    {
        [HideInInspector]public AudioManager AM;
        public Joystick joystick;
        public Animator playerAnimation;
        public float speed;
        public float rotationSmooth;

        private CharacterController controller;
        private float turnSmoothVelocity;
        private Transform cam;

        public bool Hold;

        public bool isWalk;
       

        void Start()
        {
            AM = FindObjectOfType<AudioManager>();
            controller = GetComponent<CharacterController>();
            cam = Camera.main.transform;
        }

        [SerializeField] float magnitudeTest;
        void Update()
        {
            movement();
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            playerAnimation.SetBool("hold", Hold);
            magnitudeTest = direction.magnitude;

            
        }

        [HideInInspector]public Vector3 direction;       
        void movement()
        {
            ///RbVelocity = GetComponent<Rigidbody>().velocity;

            if (GetComponent<playerStackingSystem>().ClothObject.Count > 0)
                Hold = true;
            if (GetComponent<playerStackingSystem>().ClothObject.Count <= 0)
                Hold = false;


            //float x = Input.GetAxisRaw("Vertical");
            //float z = -Input.GetAxisRaw("Horizontal");

            float x = joystick.Vertical;
            float z = -joystick.Horizontal;
            if (!isWalk)
            {
                playerAnimation.enabled = true;
                direction = new Vector3(x, 0, z).normalized;
                playerAnimation.SetFloat("vertical", Mathf.Abs(direction.magnitude));
            }
            if (isWalk)
            {
                direction = Vector3.zero;
                StartCoroutine(stopAnimation(0.2f));
                
            }
            
            
            if (direction.magnitude > 0.1f)
            {
                FindObjectOfType<GameManager>().OnMouseDownData();
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSmooth);
                transform.rotation = Quaternion.Euler(0, angle, 0);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }                        
        }

        IEnumerator stopAnimation(float t)
        {
            playerAnimation.SetFloat("vertical", 0);
            yield return new WaitForSeconds(t);
            playerAnimation.enabled = false;
        }
    }
}
