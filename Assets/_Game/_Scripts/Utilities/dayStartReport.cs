using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dayStartReport : MonoBehaviour
{
    FashionM.Core.GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<FashionM.Core.GameManager>();
    }

    [Range(0, 1)]
    public float WinVolume;
    void Update()
    {
        if (!manager.DayStart && !manager.DayOff)
        {
            manager.dayStartUI.SetActive(true);
            if (manager.dayStartUI.activeSelf)
            {
                manager.dayStartUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = manager.customerGoal.ToString() + " Customer";
            }
            FindObjectOfType<FashionM.Core.AudioManager>().source.PlayOneShot(FindObjectOfType<FashionM.Core.AudioManager>().EndOfDay, WinVolume);
        }

    }
}
