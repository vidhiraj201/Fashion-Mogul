using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;

namespace FashionM.Movement
{
    public class playerMovement : MonoBehaviour
    {
        public Joystick joystick;
        public Animator playerAnimation;
        public float speed;
        public float rotationSmooth;

        private CharacterController controller;
        private float turnSmoothVelocity;
        private Transform cam;

        public bool Hold;
        void Start()
        {
            controller = GetComponent<CharacterController>();
            cam = Camera.main.transform;
        }

        void Update()
        {
            movement();
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            playerAnimation.SetBool("hold", Hold);
        }

        [SerializeField]private Vector3 direction;
        [SerializeField]private Vector3 RbVelocity;
        void movement()
        {
            RbVelocity = GetComponent<Rigidbody>().velocity;

            if (GetComponent<playerStackingSystem>().ClothObject.Count > 0)
                Hold = true;
            if (GetComponent<playerStackingSystem>().ClothObject.Count <= 0)
                Hold = false;

            float x = joystick.Vertical;
            float z = -joystick.Horizontal;

            direction = new Vector3(x, 0, z).normalized;

            playerAnimation.SetFloat("vertical", Mathf.Abs(direction.magnitude));
            
            if (direction.magnitude > 0.1f)
            {
                FindObjectOfType<GameManager>().OnMouseDownData();
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle+45, ref turnSmoothVelocity, rotationSmooth);
                transform.rotation = Quaternion.Euler(0, angle, 0);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * new Vector3(1, 0, 1);
                controller.Move(moveDir.normalized * speed*Time.deltaTime);
            }                        
        }
    }
}
