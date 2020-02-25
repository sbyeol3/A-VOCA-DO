using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class ObjectTrackableEventHandler : DefaultTrackableEventHandler
{

    public Scene6 scene6;
    // Start is called before the first frame update
    override protected void OnTrackingFound()
    {
        base.OnTrackingFound();
        scene6.isBridgeFound = true;
        //scene6.boa_clear();
        Debug.Log("clear");
        
    }

    override protected void OnTrackingLost()
    {
        base.OnTrackingLost();
        scene6.isBridgeFound = false;
    }

}
