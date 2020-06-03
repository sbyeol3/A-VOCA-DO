using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
namespace DigitalRuby.RainMaker
{

    public class S5WrongTrackableEventHandler : DefaultTrackableEventHandler
    {
        public AudioClip[] wrong;
        public AudioSource boa_sound;
        public Scene5 scene5;
        // Start is called before the first frame update
        override protected void OnTrackingFound()
        {
            base.OnTrackingFound();
            //Scene5.isUmbrellaFound = false;
            Scene5.isWrongFound = true;
            //scene6.boa_clear();
            boa_sound.PlayOneShot(wrong[Random.Range(0, 3)]);
        }

        override protected void OnTrackingLost()
        {
            base.OnTrackingLost();
            Scene5.isWrongFound = false;
            //Scene5.isUmbrellaFound = false;
        }

    }
}