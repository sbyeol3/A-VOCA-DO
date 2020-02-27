using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;


public class S1DefaultHandler : DefaultTrackableEventHandler
{
    public S1MoveBoa s1move;
<<<<<<< HEAD
<<<<<<< HEAD

    override protected void OnTrackingFound()
    {
        base.OnTrackingFound();
        if (s1move.isSet)
        {
            StartCoroutine(s1move.InitBoa());
        }
        
=======
=======
>>>>>>> f81a3061b4667ec574610a429b4af4e4882a4058
    override protected void OnTrackingFound()
    {
        base.OnTrackingFound();
        StartCoroutine(s1move.InitBoa());
        /*        if (mTrackableBehaviour)
                {
                    Debug.Log("detect");
                    var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
                    var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
                    var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

                    // Enable rendering:
                    foreach (var component in rendererComponents)
                        component.enabled = true;

                    // Enable colliders:
                    foreach (var component in colliderComponents)
                        component.enabled = true;

                    // Enable canvas':
                    foreach (var component in canvasComponents)
                        component.enabled = true;

                    StartCoroutine(s1move.InitBoa());
                    Debug.Log("코루틴 종료");
                }

                if (OnTargetFound != null)
                    OnTargetFound.Invoke();*/

<<<<<<< HEAD
>>>>>>> f81a3061b4667ec574610a429b4af4e4882a4058
=======
>>>>>>> f81a3061b4667ec574610a429b4af4e4882a4058
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
