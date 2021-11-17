using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;

public class Watch : MonoBehaviour
{

    public Transform RotationT;
    public float Speed;
    public float Reducer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Reducer -= Speed;
        RotationT.rotation = Quaternion.Euler(0, 0, Reducer);
        if (Reducer <= 0)
        {
            Reducer = 0;
            FindObjectOfType<GameManager>().DayOff = true;
        }

    }
}
