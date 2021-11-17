using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;
using TMPro;
public class Watch : MonoBehaviour
{
    public Transform RotationT;
    public float Speed;
    public float RoationTimes;
    private float Reducer;

    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        Reducer = 360 * RoationTimes;
    }


    public void ResetReducer()
    {
        Reducer = 360 * RoationTimes;
    }
    // Update is called once per frame
    void Update()
    {
        if(Reducer > 0) 
            Reducer -= Speed;

        RotationT.rotation = Quaternion.Euler(0, 0, Reducer);
        if (Reducer <= 0 && !FindObjectOfType<GameManager>().DayOff)
        {
            Reducer = 0;
            manager.DayNightCycle.SetActive(true);
            if (manager.DayNightCycle.activeSelf)
            {
                manager.DayNightCycle.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + manager.MaxCoin.ToString();
            }
            manager.DayOff = true;

        }

    }
}
