using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;


public class S1DefaultHandler : DefaultTrackableEventHandler
{
    public S1MoveBoa s1move;

    override protected void OnTrackingFound()
    {
        base.OnTrackingFound();
        if (s1move.isSet)
        {
            StartCoroutine(s1move.InitBoa());
        }
        
    }

    override protected void OnTrackingLost()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Disable rendering:
            foreach (var component in rendererComponents)
                component.enabled = false;

            // Disable colliders:
            foreach (var component in colliderComponents)
                component.enabled = false;

            // Disable canvas':
            foreach (var component in canvasComponents)
                component.enabled = false;
        }

        if (OnTargetLost != null)
            OnTargetLost.Invoke();
    }
}
