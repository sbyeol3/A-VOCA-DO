using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDefaultHandler : DefaultTrackableEventHandler
{
    public S1MoveBoa s1move;

    override protected void OnTrackingFound()
    {
        if (!s1move.isFound)
        {
            StartCoroutine("PutHatOn");
        }
        
    }
}