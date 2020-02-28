using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void ChangeaTo1Scene()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void Change1To2Scene()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void ChangeStopScene()
    {
        SceneManager.LoadScene("Start");
    }

}

