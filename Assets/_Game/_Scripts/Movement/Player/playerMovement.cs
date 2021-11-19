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
        private Camera cam;

        public bool Hold;
        void Start()
        {
            controller = GetComponent<CharacterController>();
            cam = Camera.main;
        }

        void Update()
        {
            movement();
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            playerAnimation.SetBool("hold", Hold);
        }

        private Vector3 direction;
        void movement()
        {
            if (GetComponent<playerStackingSystem>().ClothObject.Count > 0)
                Hold = true;
            if (GetComponent<playerStackingSystem>().ClothObject.Count <= 0)
                Hold = false;

            float z = -joystick.Horizontal;
            float x = joystick.Vertical;

            direction = new Vector3(x, 0, z).normalized;
            playerAnimation.SetFloat("vertical", Mathf.Abs(direction.magnitude));
            
            if (direction.magnitude > 0.1f)
            {
                FindObjectOfType<GameManager>().OnMouseDownData();
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSmooth);
                transform.rotation = Quaternion.Euler(0, angle, 0);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed*Time.deltaTime);
            }
        }
    }
}
