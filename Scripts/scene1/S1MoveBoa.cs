using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class S1MoveBoa : MonoBehaviour
{
    private TrackableBehaviour mTrackableBehaviour;
    public GameObject boa;

    void Start(){
        boa.SetActive(false);
    }


    void Update()
    {
        
    }

    public IEnumerator MoveBoa()
    {
        boa.SetActive(true);

        boa.transform.localPosition = new Vector3(-0.32f, 0.136f, 0.02);
    }
}
