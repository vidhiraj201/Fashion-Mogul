using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Two : MonoBehaviour
{
    public Animator anim;

    public void hit()
    {
        anim.Play("Rotate");
    }
}
