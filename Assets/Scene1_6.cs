using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1_6 : MonoBehaviour
{
    public Animator cam, player;
    public ParticleSystem p;


    public void camR()
    {
        cam.Play("Pan");
    }

    public void PlayerR()
    {
        player.SetBool("p", true);
    }

    public void partical()
    {
        p.Play();
    }
}
