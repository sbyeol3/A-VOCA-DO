using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDefaultHandler : DefaultTrackableEventHandler
{
    public S1MoveBoa s1move;
    override protected void OnTrackingFound()
    {
        Debug.Log(S1MoveBoa.givenMission);
        if (S1MoveBoa.givenMission)
        {
            StartCoroutine(s1move.PutHatOn());
        }
        
    }
}