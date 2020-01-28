﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;


public class S1DefaultHandler : DefaultTrackableEventHandler
{
    public S1MoveBoa scene1;
    override protected void OnTrackingFound()
    {
        base.OnTrackingFound();
        StartCoroutine(scene1.MoveBoa());
    }

    override protected void OnTrackingLost()
    {
        base.OnTrackingLost();
    }
}
