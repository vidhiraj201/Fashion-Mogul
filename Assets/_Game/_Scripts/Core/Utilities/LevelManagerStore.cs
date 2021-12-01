using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FashionM.Core
{
    public class LevelManagerStore : MonoBehaviour
    {
        private GameManager gm;

        public Transform END;
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

        [Header("Store UI")]
        public Sprite Rack_0;
        public Sprite Rack_1;
        public Sprite Rack_2;
        public Sprite Rack_3;

        [Header("Shops")]
        public Stores RackNumber0;
        public Stores RackNumber1;
        public Stores RackNumber2;
        public Stores RackNumber3;

        [Header("Rack Open")]
        public List<int> rackOpen = new List<int>();

        private void Awake()
        {
            RackNumberAdding();
        }
        void Start()
        {
            gm = FindObjectOfType<GameManager>();
            RackNumberAdding();
        }

        void Update()
        {
            RackNumberAdding();
        }
        void RackNumberAdding()
        {
            if (Rack0 && !rackOpen.Contains(RackNumber0.RackNumber))
                rackOpen.Add(RackNumber0.RackNumber);
            if (Rack1 && !rackOpen.Contains(RackNumber1.RackNumber))
                rackOpen.Add(RackNumber1.RackNumber);
            if (Rack2 && !rackOpen.Contains(RackNumber2.RackNumber))
                rackOpen.Add(RackNumber2.RackNumber);
            if (Rack3 && !rackOpen.Contains(RackNumber3.RackNumber))
                rackOpen.Add(RackNumber3.RackNumber);
        }
    }

}