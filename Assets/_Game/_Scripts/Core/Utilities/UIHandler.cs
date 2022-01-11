using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FashionM.Control
{
    public class UIHandler : MonoBehaviour
    {
        public TextMeshProUGUI EmployeeCount;
        public TextMeshProUGUI storeSection;

        public List<GameObject> storeList = new List<GameObject>();

        private FashionM.Core.GameManager gm;
        private void Start()
        {
            gm = FindObjectOfType<FashionM.Core.GameManager>();
        }
        void Update()
        {

            storeSection.text = storeList.Count + " / 4";
            EmployeeCount.text = gm.EmployeeCount.ToString();
        }      
    }
}
