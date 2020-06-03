using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
namespace DigitalRuby.RainMaker
{

    public class S2Wrong1TrackableEventHandler : DefaultTrackableEventHandler
    {        
        public AudioClip[] wrong;
        public AudioSource boa_sound;
        public Scene2 scene2;
        // Start is called before the first frame update
        override protected void OnTrackingFound()
        {
            base.OnTrackingFound();
            Scene2.isUmbrellaFound = false;
            Scene2.isWrongFound = true;
            //scene6.boa_clear();
            boa_sound.PlayOneShot(wrong[Random.Range(0,3)]);
        }

        override protected void OnTrackingLost()
        {
            base.OnTrackingLost();
            Scene2.isWrongFound = false;
            Scene2.isUmbrellaFound = false;
        }

    }
}