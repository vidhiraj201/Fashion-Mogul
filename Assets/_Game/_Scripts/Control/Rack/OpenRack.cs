using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Control
{
    public class OpenRack : MonoBehaviour
    {
        private FashionM.Core.GameManager gm;
        private FashionM.Core.Stores st;

        public GameObject Clients,ClientPosition, SlotExpnasion;
        
        void Start()
        {
            gm = FindObjectOfType<FashionM.Core.GameManager>();
            st = GetComponent<FashionM.Core.Stores>();
        }

        // Update is called once per frame
        void Update()
        {
            if(gm.dayCount == 1)
            {
                st.MaxCoinNeedToUnlock = 0;
                Clients.SetActive(true);
                ClientPosition.SetActive(true);
                SlotExpnasion.SetActive(false);
            }
        }
    }
}
