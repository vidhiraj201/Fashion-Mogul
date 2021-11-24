using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core
{
    public class LevelManagerStore : MonoBehaviour
    {
        private GameManager gm;
        [Header("Store Objects")]
        public GameObject AiPosForRack0;
        public GameObject AiPosForRack1;
        public GameObject AiPosForRack2;
        public GameObject AiPosForRack3;

        [Header("Stores")]
        public bool Rack0;
        public bool Rack1;
        public bool Rack2;
        public bool Rack3;

        [Header("Rack Open")]
        public List<int> rackOpen = new List<int>();
        void Start()
        {
            gm = FindObjectOfType<GameManager>();
        }

        void Update()
        {
            RackNumberAdding();
        }
        void RackNumberAdding()
        {
            if (Rack0 && !rackOpen.Contains(0))
                rackOpen.Add(0);
            if (Rack1 && !rackOpen.Contains(1))
                rackOpen.Add(1);
            if (Rack2 && !rackOpen.Contains(2))
                rackOpen.Add(2);
            if (Rack3 && !rackOpen.Contains(3))
                rackOpen.Add(3);
        }
    }

}