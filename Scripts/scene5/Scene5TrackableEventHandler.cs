using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class Scene5TrackableEventHandler : DefaultTrackableEventHandler
{

    public Scene5 scene5;
    // Start is called before the first frame update
    override protected void OnTrackingFound()
    {
        base.OnTrackingFound();
        //StartCoroutine(scene6.boa_set());
        Debug.Log("found");
        Scene5.isBgFound = true;
    }

    override protected void OnTrackingLost()
    {
        //base.OnTrackingLost();
        Scene5.isBgFound = false;
    }

}
