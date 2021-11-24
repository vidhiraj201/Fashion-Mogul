using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FashionM.Control;

namespace FashionM.Core
{
    public class UIButton_Stores : MonoBehaviour
    {
        private GameManager gm;
        private playerControl PControl;      
        private TextMeshProUGUI BName;        
        [SerializeField]int StationCountData;
        private void Start()
        {
            gm = FindObjectOfType<GameManager>();
            PControl = FindObjectOfType<playerControl>();
            BName = transform.GetComponentInChildren<TextMeshProUGUI>();
            BName.text = transform.name;
        }

        private void Update()
        {
        }

        public void DeductAmount()
        {
            if (PControl.SE!=null && gm.MaxCoin>= PControl.SE.MaxCoinNeedToUnlock && PControl.SE.MaxCoinNeedToUnlock>=0)
            {
                Instantiate(gm.RightRoadFacingStations[StationCountData], new Vector3(PControl.SE.PlacingPosition.x, PControl.SE.PlacingPosition.y, PControl.SE.PlacingPosition.z),Quaternion.Euler(PControl.SE.PlacingRotation)).transform.parent = GameObject.Find("Expanded Store").transform;
                gm.MaxCoin -= PControl.SE.MaxCoinNeedToUnlock;
                PControl.SE.MaxCoinNeedToUnlock = 0;
                gm.UnlockStoreExpansionUI.gameObject.GetComponent<Animator>().Play("Out");
                PControl.SE = null;
            }
        }
    }
}
