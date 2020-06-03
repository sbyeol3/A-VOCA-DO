using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sceneA : MonoBehaviour
{
    public GameObject boa, present;
    public GameObject nextbtn, stopbtn, missionText;
    public Animator walk;
    public Animator jump;

    public Material[] facial;
    public SkinnedMeshRenderer face;
    public AudioSource nar;
    public AudioClip startAudio, endAudio;
    public bool isPlayedStart, isPlayedEnd = false;

    public Image askFinish;
    public bool giveMission = false;
    public bool isCalled = false;

    void Awake()
    {
        nextbtn.SetActive(false);
        stopbtn.SetActive(false);
        boa.transform.Rotate(0f, -180f, 0f);
        present.SetActive(false);
        missionText.SetActive(false);
        askFinish.gameObject.SetActive(false);
        face.material = facial[0];
    }

    public IEnumerator InitBoa()
    {
        isCalled = true;
        boa.transform.localPosition = new Vector3(0.378f, 0.19f, -0.992f); // init boa's position
        boa.transform.Rotate(0f, 190.693f, 0f);
        jump.SetBool("isJump", true);
        yield return new WaitForSeconds(0.8f);
        jump.SetBool("isJump", false);
        for (int i = 0; i < 10; i++) // -0.038 0.341 -0.398
        {
            boa.transform.localPosition = boa.transform.localPosition + new Vector3(-0.0416f, 0.0151f, 0.0594f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.05f);
        for (int i = 0; i < 10; i++) // -0.448 0.032 -1.38
        {
            boa.transform.localPosition = boa.transform.localPosition + new Vector3(-0.0416f, -0.0309f, -0.0982f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.3f);
        boa.transform.Rotate(0f, -59.6f, 0f);

        StartCoroutine("GiveMission");
    }


    public IEnumerator GiveMission()
    {
        giveMission = true;
        missionText.SetActive(true);
        if (!isPlayedStart)
        {
            nar.PlayOneShot(startAudio);
            isPlayedStart = true;
        }
        yield return new WaitForSeconds(0.3f);
    }


    public IEnumerator Mission()
    {
        missionText.SetActive(false);
        if (!isPlayedEnd)
        {
            nar.PlayOneShot(endAudio);
            isPlayedEnd = true;
        }
        present.SetActive(true);
        //present.transform.localPosition = new Vector3(-0.5f, 0.06f, -0.5f);
        face.material = facial[1];
        yield return new WaitForSeconds(5.0f);
        nextbtn.SetActive(true);
        stopbtn.SetActive(true);
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
