using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;


public class PresentDefaultHandler : DefaultTrackableEventHandler
{
    public sceneA a;
    override protected void OnTrackingFound()
    {
        base.OnTrackingFound();
        if(a.giveMission)
            StartCoroutine(a.Mission());
    }

    override protected void OnTrackingLost()
    {
        //base.onTrackingLost();
    }
}
