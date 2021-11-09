using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USUI : MonoBehaviour
{ 
    public void deactivateUI()
    {
        transform.gameObject.SetActive(false);
    }
}
