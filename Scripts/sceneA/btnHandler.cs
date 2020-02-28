using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
using UnityEngine.SceneManagement;


public class btnHandler : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject btnObj;

    void Start()
    {
        btnObj = GameObject.Find("nextBtn");
        btnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        Debug.Log("Start");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("a");
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) // 버튼 눌렀을 때
    {
        Debug.Log("Press");
        ChangeNextScene();
    }

    public void ChangeNextScene()
    {
        SceneManager.LoadScene("Start");
    }
}
