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
}
