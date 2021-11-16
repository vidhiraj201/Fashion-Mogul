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
        private Image BUI;
        private TextMeshProUGUI BName;        
        [SerializeField]int StationCountData;
        private bool isButtonPressed = false;
        private void Start()
        {
            gm = FindObjectOfType<GameManager>();
            PControl = FindObjectOfType<playerControl>();
            BUI = GetComponent<Image>();
            BName = transform.GetComponentInChildren<TextMeshProUGUI>();
            BName.text = transform.name;
        }

        private void Update()
        {
            ButtonCheck();
        }

        public void ButtonCheck()
        {
            if (isButtonPressed)
                CheckStore();

            if (gm.Ex1 && StationCountData == 0)
            {
                BUI.color = new Color32(202, 202, 202, 160);
                BName.color = new Color32(202, 202, 202, 160);
                transform.GetComponent<Button>().enabled = false;
            }

            if (gm.Ex2 && StationCountData == 1)
            {
                BUI.color = new Color32(202, 202, 202, 160);
                BName.color = new Color32(202, 202, 202, 160);
                transform.GetComponent<Button>().enabled = false;
            }

            if (gm.Ex3 && StationCountData == 2)
            {
                BUI.color = new Color32(202, 202, 202, 160);
                BName.color = new Color32(202, 202, 202, 160);
                transform.GetComponent<Button>().enabled = false;
            }

            if (gm.Ex4 && StationCountData == 3)
            {
                BUI.color = new Color32(202, 202, 202, 160);
                BName.color = new Color32(202, 202, 202, 160);
                transform.GetComponent<Button>().enabled = false;
            }
        }

        public void DeductAmount()
        {
            if (PControl.SE!=null && gm.MaxCoin>= PControl.SE.MaxCoinNeedToUnlock && PControl.SE.MaxCoinNeedToUnlock>=0)
            {
                isButtonPressed = true;
                Instantiate(gm.Stations[StationCountData], new Vector3(PControl.SE.PlacingPosition.x, PControl.SE.PlacingPosition.y, PControl.SE.PlacingPosition.z), Quaternion.Euler(0,-90,0)).transform.parent = GameObject.Find("Expanded Store").transform;
                gm.MaxCoin -= PControl.SE.MaxCoinNeedToUnlock;
                PControl.SE.MaxCoinNeedToUnlock = 0;
                gm.UnlockStoreExpansionUI.gameObject.GetComponent<Animator>().Play("Out");
                PControl.SE = null;
            }
        }

        public void CheckStore()
        {
            if (StationCountData == 0)
            {
                gm.Ex1 = true;
            }

            if (StationCountData == 1)
            {
                gm.Ex2 = true;
            }

            if (StationCountData == 2)
            {
                gm.Ex3 = true;
            }

            if (StationCountData == 3)
            {
                gm.Ex4 = true;
            }
        }
       

    }
}
