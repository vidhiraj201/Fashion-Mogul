using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5Look : MonoBehaviour
{

    public bool look = false;
    public Transform Target;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (look)
        {
            player.LookAt(new Vector3(Target.position.x, player.position.y, Target.position.z));
        }
    }

    public void lookTrue()
    {
        look = true;
    }
}
