using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class Scene6TrackableEventHandler : DefaultTrackableEventHandler
{

    public Scene6 scene6;
    // Start is called before the first frame update
    override protected void OnTrackingFound()
    {
        base.OnTrackingFound();
        //StartCoroutine(scene6.boa_set());
        Debug.Log("found");
        Scene6.isBgFound = true;
    }

    override protected void OnTrackingLost()
    {
        //base.OnTrackingLost();
        Scene6.isBgFound = false;
    }

}
