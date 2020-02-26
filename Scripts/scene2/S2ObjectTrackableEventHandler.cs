using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

namespace DigitalRuby.RainMaker
{
    public class S2ObjectTrackableEventHandler : DefaultTrackableEventHandler
    {

        public Scene2 scene2;
        // Start is called before the first frame update
        override protected void OnTrackingFound()
        {
            base.OnTrackingFound();
            Scene2.isUmbrellaFound = true;
            //scene6.boa_clear();
            Debug.Log("clear");

        }

        override protected void OnTrackingLost()
        {
            base.OnTrackingLost();
            Scene2.isUmbrellaFound = false;
        }

    }
}