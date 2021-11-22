using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core
{
    public class LevelManager : MonoBehaviour
    {
        private GameManager gm;

        void Start()
        {
            gm = FindObjectOfType<GameManager>();
        }

        void Update()
        {

        }
        void WatchOpen()
        {
        }
    }

}