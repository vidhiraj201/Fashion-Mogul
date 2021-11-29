using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Core;

namespace FashionM.Movement {
    public class PlaySound : MonoBehaviour
    {
        private AudioManager AM;

        [Range(0,1)]
        public float volume;
        // Start is called before the first frame update
        void Start()
        {
            AM = FindObjectOfType<AudioManager>();
        }

        public void hitWalk()
        {
            //AM.source.PlayOneShot(AM.Footsteps, volume);
        }
    }
}
