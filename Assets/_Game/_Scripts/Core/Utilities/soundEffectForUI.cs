using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffectForUI : MonoBehaviour
{
    public AudioSource asd;
    public AudioClip c1;
    public AudioClip c2;

    public void click1()
    {
        asd.PlayOneShot(c1, 1);
    }
    public void click2()
    {
        asd.PlayOneShot(c2, 1);
    }
}
