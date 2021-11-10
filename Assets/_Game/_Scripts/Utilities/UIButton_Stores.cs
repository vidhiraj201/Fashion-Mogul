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

        public bool basicCloths, premiumCloths, exclusiveBrand, jewllry;
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

            if (gm.basicCloths && basicCloths)
            {
                BUI.color = new Color32(202, 202, 202, 160);
                BName.color = new Color32(202, 202, 202, 160);
                transform.GetComponent<Button>().enabled = false;
            }

            if (gm.premiumCloths && premiumCloths)
            {
                BUI.color = new Color32(202, 202, 202, 160);
                BName.color = new Color32(202, 202, 202, 160);
                transform.GetComponent<Button>().enabled = false;
            }

            if (gm.exclusiveBrand && exclusiveBrand)
            {
                BUI.color = new Color32(202, 202, 202, 160);
                BName.color = new Color32(202, 202, 202, 160);
                transform.GetComponent<Button>().enabled = false;
            }

            if (gm.jewllry && jewllry)
            {
                BUI.color = new Color32(202, 202, 202, 160);
                BName.color = new Color32(202, 202, 202, 160);
                transform.GetComponent<Button>().enabled = false;
            }
        }

        public void DeductAmount()
        {            
            if (PControl.OR !=null && PControl.OR.transform.name == transform.name && gm.MaxCoin >= PControl.OR.MaxCoinNeedToUnlock && PControl.OR.MaxCoinNeedToUnlock > 0)
            {
                gm.MaxCoin -= PControl.OR.MaxCoinNeedToUnlock;
                CheckStore();
                PControl.OR.MaxCoinNeedToUnlock = 0;
                PControl.OR.RackPrice.text = "$" + PControl.OR.MaxCoinNeedToUnlock.ToString();
                gm.UnlockStoreUI.GetComponent<Animator>().Play("Out");
                
            }
        }

        public void CheckStore()
        {
            if(premiumCloths)
            {
                gm.premiumCloths = true;
            }
            if (exclusiveBrand)
            {
                gm.exclusiveBrand = true;
            }
            if (jewllry)
            {
                gm.jewllry = true;
            }
        }
       

    }
}
