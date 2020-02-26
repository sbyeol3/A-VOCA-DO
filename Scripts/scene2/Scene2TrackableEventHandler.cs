using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;


namespace DigitalRuby.RainMaker
{

    public class Scene2TrackableEventHandler : DefaultTrackableEventHandler
    {

        public Scene2 scene2;
        // Start is called before the first frame update
        override protected void OnTrackingFound()
        {
            base.OnTrackingFound();
            //StartCoroutine(scene6.boa_set());
            Debug.Log("found");
            Scene2.isBgFound = true;
        }

        override protected void OnTrackingLost()
        {
            //base.OnTrackingLost();
            Scene2.isBgFound = false;
        }

    }
}
