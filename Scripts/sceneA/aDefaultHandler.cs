using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;


public class aDefaultHandler : DefaultTrackableEventHandler
{
    public sceneA a;
    override protected void OnTrackingFound()
    {
        base.OnTrackingFound();
        if (!a.isCalled)
        {
            StartCoroutine(a.InitBoa());
        }
            
    }

    override protected void OnTrackingLost()
    {
        //base.onTrackingLost();
    }
}
