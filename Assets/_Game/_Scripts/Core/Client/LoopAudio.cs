using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core 
{
    public class LoopAudio : MonoBehaviour
    {
        private AudioSource AS;
        public AudioClip musicStart;
        private Stores ST;
        // Start is called before the first frame update
        void Start()
        {
            AS = GetComponent<AudioSource>();
            ST = GetComponentInParent<Stores>();
        }

        // Update is called once per frame
        void Update()
        {
            if (ST.PlayerIsOnClosedRack)
            {
                AS.volume = 0.3f;
                AS.PlayOneShot(musicStart, AS.volume);
                AS.PlayScheduled(AudioSettings.dspTime + musicStart.length);
            }

            if (!ST.PlayerIsOnClosedRack && AS.volume >=0)
            {
                AS.volume -= 10f * Time.deltaTime;
            }
                
        }
    }
}

