using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class S5ObjectTrackableEventHandler : DefaultTrackableEventHandler
{

    public Scene5 scene5;
    // Start is called before the first frame update
    override protected void OnTrackingFound()
    {
        base.OnTrackingFound();
        Scene5.isBalloonFound = true;
        //scene6.boa_clear();
        Debug.Log("clear");

    }

    override protected void OnTrackingLost()
    {
        base.OnTrackingLost();
        Scene5.isBalloonFound = false;
    }

}
