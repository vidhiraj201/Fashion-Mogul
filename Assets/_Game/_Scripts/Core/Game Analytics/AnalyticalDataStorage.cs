using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using Facebook.Unity;
public class AnalyticalDataStorage : MonoBehaviour
{

    GAProgressionStatus levelStatus;
    private void Awake()
    {        
        
        FB.Init();        
    }
    private void Start()
    {
        GameAnalytics.Initialize();
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
        int i = dayDataCount + 1;
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Day : " + (dayDataCount + 1) + " Total Customer : " + customerIncoming);
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Day : ",i.ToString("D4"));

        //GameAnalytics.NewDesignEvent("Start Day : " + i);
        /*GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Day : ", (float)i,"Day Data","Day Started");*/

        print("DAY START DATA SENT TO _GAME ANALYTICS_");
    }
    public void dayEndData(int dayDataCount, int customerServed)
    {
        int i = dayDataCount + 1;
        GameAnalytics.NewProgressionEvent(levelStatus, i.ToString("D4"));
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Day : " + (dayDataCount + 1) + " Total Customer Served : " + customerServed);

        /*GameAnalytics.NewDesignEvent("End Day : " + i);
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Day : ", (float)i, "Day Data", "Day Ended");*/

        print("DAY END DATA SENT TO _GAME ANALYTICS_");
    }
}
