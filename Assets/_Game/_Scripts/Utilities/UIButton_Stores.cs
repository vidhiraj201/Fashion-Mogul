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
        public TextMeshProUGUI amount;
        [SerializeField]int StationCountData;
        private void Awake()
        {
            gm = FindObjectOfType<GameManager>();
            PControl = FindObjectOfType<playerControl>();
            BName = transform.GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            if(PControl.SE != null)
            {
                amount.text = PControl.SE.MaxCoinNeedToUnlock.ToString();
            }
        }

        public void DeductAmount()
        {
            if(PControl.SE != null &&  PControl.SE.facingSide == 0)
            {
                if (gm.MaxCoin >= PControl.SE.MaxCoinNeedToUnlock && PControl.SE.MaxCoinNeedToUnlock >= 0)
                {
                    Instantiate(gm.LeftAndRightFacingStation[StationCountData], PControl.SE.lv.transform.position+new Vector3(PControl.SE.xPos,0,0), Quaternion.Euler(PControl.SE.PlacingRotation)).transform.parent = GameObject.Find("Expanded Store").transform;
                    gm.MaxCoin -= PControl.SE.MaxCoinNeedToUnlock;
                    PControl.SE.MaxCoinNeedToUnlock = 0;
                    gm.UnlockStoreExpansionUI.gameObject.GetComponent<Animator>().Play("Out");
                    PControl.SE = null;
                }
            }

            if (PControl.SE != null &&  PControl.SE.facingSide == 1)
            {
                if (gm.MaxCoin >= PControl.SE.MaxCoinNeedToUnlock && PControl.SE.MaxCoinNeedToUnlock >= 0)
                {
                    Instantiate(gm.LeftRoadFacingStation[StationCountData], PControl.SE.lv.transform.position - new Vector3(PControl.SE.xPos, 0, 0), Quaternion.Euler(PControl.SE.PlacingRotation)).transform.parent = GameObject.Find("Expanded Store").transform;
                    gm.MaxCoin -= PControl.SE.MaxCoinNeedToUnlock;
                    PControl.SE.MaxCoinNeedToUnlock = 0;
                    gm.UnlockStoreExpansionUI.gameObject.GetComponent<Animator>().Play("Out");
                    PControl.SE = null;
                }
            }

            if (PControl.SE!=null &&  PControl.SE.facingSide == 2)
            {
                if (gm.MaxCoin >= PControl.SE.MaxCoinNeedToUnlock && PControl.SE.MaxCoinNeedToUnlock >= 0)
                {
                    Instantiate(gm.RightRoadFacingStations[StationCountData], PControl.SE.lv.transform.position - new Vector3(0, 0, PControl.SE.zPos), Quaternion.Euler(PControl.SE.PlacingRotation)).transform.parent = GameObject.Find("Expanded Store").transform;
                    gm.MaxCoin -= PControl.SE.MaxCoinNeedToUnlock;
                    PControl.SE.MaxCoinNeedToUnlock = 0;
                    gm.UnlockStoreExpansionUI.gameObject.GetComponent<Animator>().Play("Out");
                    PControl.SE = null;
                }
            }

            if (PControl.SE != null && PControl.SE.facingSide == 3)
            {
                if (gm.MaxCoin >= PControl.SE.MaxCoinNeedToUnlock && PControl.SE.MaxCoinNeedToUnlock >= 0)
                {
                    Instantiate(gm.NoRoadFacingStation[StationCountData], PControl.SE.lv.transform.position - new Vector3(PControl.SE.xPos, 0, PControl.SE.zPos), Quaternion.Euler(PControl.SE.PlacingRotation)).transform.parent = GameObject.Find("Expanded Store").transform;
                    gm.MaxCoin -= PControl.SE.MaxCoinNeedToUnlock;
                    PControl.SE.MaxCoinNeedToUnlock = 0;
                    gm.UnlockStoreExpansionUI.gameObject.GetComponent<Animator>().Play("Out");
                    PControl.SE = null;
                }
            }


        }
    }
}
