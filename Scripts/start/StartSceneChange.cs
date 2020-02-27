using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneChange : MonoBehaviour
{   
    public void ChangeStartScene()
    {
        //SceneManager.LoadScene("");
    }

    public void ChangeHowToScene()
    {
        SceneManager.LoadScene("HowTo");
    }
}

