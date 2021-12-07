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
            StartCoroutine(DayOffLag(0.2f));
        }

    }

    IEnumerator DayOffLag(float t)
    {
        try
        {
            FindObjectOfType<FashionM.Core.playerStackingSystem>().resetStacking();
            FindObjectOfType<FashionM.Core.EmpStackingSystem>().poofCloth();
        }
        catch
        {

        }
        FindObjectOfType<FashionM.Movement.playerMovement>().isWalk = true;
        yield return new WaitForSeconds(t);
        manager.dayCompleteUI.SetActive(true);
        manager.DayStart = false;
        manager.DayOff = true;
        FindObjectOfType<FashionM.Core.AudioManager>().source.PlayOneShot(FindObjectOfType<FashionM.Core.AudioManager>().EndOfDay, WinVolume);
        if (manager.dayCompleteUI.activeSelf)
        {
            //manager.dayCompleteUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + manager.MaxCoin.ToString();
        }

    }
}
