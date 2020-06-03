using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongCardHandler : DefaultTrackableEventHandler
{
    public AudioSource boa;
    public AudioClip[] wrong;

    override protected void OnTrackingFound()
    {
        boa.clip = wrong[Random.Range(0, 3)];
        boa.Play();
    }
}