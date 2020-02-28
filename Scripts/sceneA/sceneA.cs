using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneA : MonoBehaviour
{
    public GameObject boa;
    public GameObject present;
    public GameObject nextbtn;
    public GameObject stopbtn;
    public Animator walk;
    public Animator jump;


    public Material[] facial;
    public SkinnedMeshRenderer face;

    public bool giveMission = false;
    public bool isCalled = false;

    void Awake()
    {
        nextbtn.SetActive(false);
        stopbtn.SetActive(false);
        boa.transform.Rotate(0f, -180f, 0f);
        present.SetActive(false);
        face.material = facial[0];
    }

    public IEnumerator InitBoa()
    {
        isCalled = true;
        boa.transform.localPosition = new Vector3(0.378f, 0.19f, -0.992f); // init boa's position
        boa.transform.Rotate(0f, 239.693f, 0f);
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
        //오디오 파일 재생 "present를 주ㅓ"
        yield return new WaitForSeconds(0.3f);
    }


    public IEnumerator Mission()
    {
        // 오디오파일 재생 "고마워"
        present.SetActive(true);
        present.transform.localPosition = new Vector3(0.8826f, -1.731f, -1.7793f);
        face.material = facial[1];
        yield return new WaitForSeconds(1.0f);
        nextbtn.SetActive(true);
        stopbtn.SetActive(true);
    }
}
