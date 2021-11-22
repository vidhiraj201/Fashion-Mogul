using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;
using TMPro;
public class Watch : MonoBehaviour
{

    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.CustomerIncrement >= manager.customerGoal && !FindObjectOfType<GameManager>().DayOff)
        {
            manager.DayNightCycle.SetActive(true);
            if (manager.DayNightCycle.activeSelf)
            {
                manager.DayNightCycle.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + manager.MaxCoin.ToString();
            }
            manager.DayOff = true;
        }

    }
}
