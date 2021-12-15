using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using Facebook.Unity;
public class AnalyticalDataStorage : MonoBehaviour
{
    private void Awake()
    {        
        GameAnalytics.Initialize();
        FB.Init();        
    }
    public void StoreExpansionSentData(Transform t)
    {
        GameAnalytics.NewDesignEvent("Section Unlocked : " + t.name);
        print("SECTION DATA SENT TO _GAME ANALYTICS_");
    }
    public void EmployeeHire(int i)
    {
        GameAnalytics.NewDesignEvent("Total Hired Employee : " + i);
        print("EMPLOYEE DATA SENT TO _GAME ANALYTICS_");
    }

    public void dayStartData(int dayDataCount, int customerIncoming)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Day : "+(dayDataCount + 1) +" Total Customer : "+ customerIncoming);
        print("DAY START DATA SENT TO _GAME ANALYTICS_");
    }
    public void dayEndData(int dayDataCount, int customerServed)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Day : " + (dayDataCount + 1) + " Total Customer Served : " + customerServed);
        print("DAY END DATA SENT TO _GAME ANALYTICS_");
    }
}
