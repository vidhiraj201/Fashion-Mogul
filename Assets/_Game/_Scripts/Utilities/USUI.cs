using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USUI : MonoBehaviour
{
    public GameObject parent;
    public void deactivateUI()
    {        
        if(parent == null)
            transform.gameObject.SetActive(false);


        if (parent != null)
                parent.SetActive(false);
    }

    public void startDay()
    {
        FindObjectOfType<FashionM.Core.GameManager>().DayStart = true;
        FindObjectOfType<FashionM.Movement.playerMovement>().isWalk = false;
        FindObjectOfType<FashionM.Core.GameManager>().InfintyUI.SetActive(true);
    }
}
