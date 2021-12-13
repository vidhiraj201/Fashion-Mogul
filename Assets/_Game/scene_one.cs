using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_one : MonoBehaviour
{
    public bool startCam;
    public Animator cam;
    private void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DoorChecker"))
        {
            try
            {
               // cam.Play("Customer Walk in");
            }
            catch
            {

            }
            startCam = true;
        }
    }
}
