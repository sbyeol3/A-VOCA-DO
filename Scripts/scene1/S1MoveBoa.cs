using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S1MoveBoa : MonoBehaviour
{
    public Transform target;
    public GameObject boa;
    public Animator walk;

    public AudioSource nar;
    public AudioClip startAudio, endAudio;
    
    public bool isSet = true;
    public static bool givenMission = false;
    public bool isPlayedStart,isPlayedEnd = false;
    public GameObject hat;
    public Image askFinish;
    public GameObject nextBtn, stopBtn;
    public GameObject missionTxt;

    void Awake()
    {
        hat.SetActive(false);
        nextBtn.SetActive(false);
        stopBtn.SetActive(false);
        missionTxt.SetActive(false);
        askFinish.gameObject.SetActive(false);
        
    }


    public IEnumerator InitBoa()
    {
        boa.SetActive(true);
        isSet = false;
        target.transform.localPosition = new Vector3(0.15f, 0.013f, 0.1f); // initialize Boa's position

        walk.SetBool("isWalk", true);
        for (int i = 0;i < 95; i++){
            boa.transform.localPosition = boa.transform.localPosition + new Vector3(0.004f, 0, 0f);
            yield return new WaitForSeconds(0.1f);
        }
        walk.SetBool("isWalk", false);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine("Mission");
    }


    public IEnumerator Mission() // 현관으로 이동하기
    {
        if (!isPlayedStart)
        {
            nar.PlayOneShot(startAudio);
            isPlayedStart = true;
        }
        
        missionTxt.SetActive(true);
        givenMission = true;
        yield return new WaitForSeconds(2.0f);
        
    }

    public IEnumerator PutHatOn() // 모자
    {
        missionTxt.SetActive(false);
        givenMission = true;

        if (!isPlayedEnd)
        {
            nar.PlayOneShot(endAudio);
            isPlayedEnd = true;
        }

        hat.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        nextBtn.SetActive(true);
        stopBtn.SetActive(true);
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
