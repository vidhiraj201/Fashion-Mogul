using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class dayCompleteReport : MonoBehaviour
{
    FashionM.Core.GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<FashionM.Core.GameManager>();
    }

    [Range(0,1)]
    public float WinVolume;
    void Update()
    {
        if (manager.CustomerOut >= manager.customerGoal && !manager.DayOff)
        {
            FindObjectOfType<FashionM.Movement.playerMovement>().isWalk = true;
            manager.dayCompleteUI.SetActive(true);
            if (manager.dayCompleteUI.activeSelf)
            {
                //manager.dayCompleteUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + manager.MaxCoin.ToString();
            }
            manager.DayOff = true;
            FindObjectOfType<FashionM.Core.AudioManager>().source.PlayOneShot(FindObjectOfType<FashionM.Core.AudioManager>().EndOfDay, WinVolume);
        }

    }
}
