using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class S2TrackableEventHandler : DefaultTrackableEventHandler
{

    public Scene2 scene2;

    override protected void OnTrackingFound()
    {
        base.OnTrackingFound();
        Debug.Log("found");
        scene2.detectedPage = true;
    }

    override protected void OnTrackingLost()
    {
        base.OnTrackingLost();
        scene2.detectedPage = false;
    }
}
