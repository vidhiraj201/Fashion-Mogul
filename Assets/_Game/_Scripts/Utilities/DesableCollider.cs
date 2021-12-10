using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;

public class DesableCollider : MonoBehaviour
{
    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (manager.dayCount == 1)
        {
            GetComponent<Collider>().enabled = false;
        }
        if (manager.dayCount != 1)
        {
            GetComponent<Collider>().enabled = true;
        }
    }
}
