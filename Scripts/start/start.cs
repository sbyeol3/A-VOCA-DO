using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public Image Main, Howto, askFinish;
    public Canvas MainCanvas, Select;
    public AudioSource src;
    public AudioClip bgm;
    // Start is called before the first frame update
    void Start()
    {
        askFinish.gameObject.SetActive(false);
        Howto.gameObject.SetActive(false);
        Main.gameObject.SetActive(true);
        Select.gameObject.SetActive(false);
        src.clip = bgm;
        src.Play();
    }

    public void OpenHowto()
    {
        Main.gameObject.SetActive(false);
        Howto.gameObject.SetActive(true);
    }

    public void CloseHowto()
    {
        Main.gameObject.SetActive(true);
        Howto.gameObject.SetActive(false);
    }

    public void OpenSelect()
    {
        Select.gameObject.SetActive(true);
        MainCanvas.gameObject.SetActive(false);
    }

    public void AskExit()
    {
        askFinish.gameObject.SetActive(true);
    }

    public void NoExit()
    {
        askFinish.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
