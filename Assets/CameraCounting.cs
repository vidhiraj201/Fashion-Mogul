using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraCounting : MonoBehaviour
{
    public int i = 0;

    public bool isCamera;
    public bool isPlayer;

    public List<Transform> pos = new List<Transform>();
    public NavMeshAgent AI;
    public Animator anim;

    private float turnSmoothVelocity;
    private float rotationSmooth = 0.1f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {            
            i++;
        }
        if (isCamera)
        {
            GetComponent<Animator>().SetInteger("num", i);            
        }
        if (isPlayer)
        {
            print(AI.velocity.magnitude);
            anim.SetFloat("vertical", AI.velocity.magnitude);
            if (i >= 1)
            {
                AI.SetDestination(pos[i - 1].position);
                if (AI.velocity.magnitude > 0.1f)
                {
                    
                    float targetAngle = Mathf.Atan2(AI.velocity.x, AI.velocity.z) * Mathf.Rad2Deg;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSmooth);
                    transform.rotation = Quaternion.Euler(0, angle, 0);
                }
            }
        }
    }
}
