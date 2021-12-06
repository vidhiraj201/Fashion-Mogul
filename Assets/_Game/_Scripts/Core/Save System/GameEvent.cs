using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
/*    public static System.Action<ExpandedData> ItemAddedToInventory;
    public static System.Action<string> TooltipActivated;*/
/*    public static System.Action TooltipDeactivated;*/
    public static System.Action SaveInitiated;

/*    public static void OnItemAddedToInventory(Item item)
    {
        ItemAddedToInventory?.Invoke(item);
    }
*/
/*    public static void OnTooltipActivated(string text)
    {
        TooltipActivated?.Invoke(text);
    }*/

/*    public static void OnTooltipDeactivated()
    {
        TooltipDeactivated?.Invoke();
    }*/

    public static void OnSaveInitiated()
    {
        SaveInitiated?.Invoke();
    }
    private void OnApplicationQuit()
    {
        OnSaveInitiated();
    }
}
