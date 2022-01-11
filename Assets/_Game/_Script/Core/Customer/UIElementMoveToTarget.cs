using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementMoveToTarget : MonoBehaviour
{
    public Transform target;
    public float speed;
    Vector3 targetPos;
    Camera cam;

    FashionM.Core.customerServedUI customerServedUI;
    private void Start()
    {
        customerServedUI = FindObjectOfType<FashionM.Core.customerServedUI>();
        target = customerServedUI.target;
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    private void FixedUpdate()
    {
        //targetPos = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * 1));      

        transform.localScale = new Vector3(1, 1, 1);
        targetPos = target.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        transform.forward = -Camera.main.transform.forward;
        if (transform.position == targetPos)
        {
            FindObjectOfType<FashionM.Core.GameManager>().serveredCustomers();
            Destroy(this.gameObject);
        }
    }
}
