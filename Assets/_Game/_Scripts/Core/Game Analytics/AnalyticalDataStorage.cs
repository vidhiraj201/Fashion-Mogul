using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
public class AnalyticalDataStorage : MonoBehaviour
{
    string currency = "Test";
    string itemType = "Test";
    string itemId = "Test";
    string cartType = "Test";
    public void SentData(int amount)
    {
        GameAnalytics.NewBusinessEvent(currency, amount, itemType, itemId, cartType);
    }
}
