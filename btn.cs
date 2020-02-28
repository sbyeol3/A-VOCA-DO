using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;


public class btn : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject btnObj;
    
    void Start()
    {
        btnObj = GameObject.Find("nextBtn");
        btnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("a");
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Press");
    }
}
