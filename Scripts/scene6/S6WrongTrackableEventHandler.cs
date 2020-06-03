using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
namespace DigitalRuby.RainMaker
{

    public class S6WrongTrackableEventHandler : DefaultTrackableEventHandler
    {
        public AudioClip[] wrong;
        public AudioSource boa_sound;
        public Scene6 scene6;
        // Start is called before the first frame update
        override protected void OnTrackingFound()
        {
            base.OnTrackingFound();
            //Scene5.isUmbrellaFound = false;
            Scene6.isWrongFound = true;
            //scene6.boa_clear();
            boa_sound.PlayOneShot(wrong[Random.Range(0, 3)]);
        }

        override protected void OnTrackingLost()
        {
            base.OnTrackingLost();
            Scene6.isWrongFound = false;
            //Scene6.isUmbrellaFound = false;
        }

    }
}