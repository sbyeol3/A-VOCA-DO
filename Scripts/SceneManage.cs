using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public static Scene[] scenes;

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene("Scene"+index);
    }

    public void ChangeFirst()
    {
        SceneManager.LoadScene("Scene0");
    }

    public void ChangeStopScene()
    {
        SceneManager.LoadScene("Start");
    }
    public void ChangeHowToScene()
    {
        SceneManager.LoadScene("HowTo");
    }

}

