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

    [Range(0,1)]
    public float WinVolume;
    void Update()
    {
        if (manager.CustomerOut >= manager.customerGoal && !FindObjectOfType<GameManager>().DayOff)
        {
            manager.DayNightCycle.SetActive(true);
            if (manager.DayNightCycle.activeSelf)
            {
                manager.DayNightCycle.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + manager.MaxCoin.ToString();
            }
            manager.DayOff = true;
            FindObjectOfType<AudioManager>().source.PlayOneShot(FindObjectOfType<AudioManager>().EndOfDay, WinVolume);
        }

    }
}
