using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1MoveBoa : MonoBehaviour
{
    public Transform target;
    public GameObject boa;
    public Animator walk;

    private AudioSource audioFile;
    public bool isSet = true;
    public bool isFound = false;
    public GameObject hat;


    void Awake()
    {
        hat.SetActive(false);
    }


    public IEnumerator InitBoa()
    {
        boa.SetActive(true);
        isSet = false;
        target.transform.localPosition = new Vector3(-0.015f, 0.013f, -0.0138f); // pos 초기화
        Debug.Log("초기화");
        Debug.Log(boa.transform.localPosition);
        this.audioFile = this.gameObject.AddComponent<AudioSource>();
        //this.audioFile.clip = this.example;
        this.audioFile.loop = false;

        walk.SetBool("isWalk", true);
        for (int i = 0;i < 95; i++){
            boa.transform.localPosition = boa.transform.localPosition + new Vector3(0.004f, 0, 0f);
            Debug.Log(boa.transform.localPosition);
            yield return new WaitForSeconds(0.1f);
        }
        walk.SetBool("isWalk", false);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine("Mission");
    }

    public IEnumerator Mission() // 현관으로 이동하기
    {
        this.audioFile.Play(); // 안경을 줘~
        yield return new WaitForSeconds(2.0f);
        
    }

    public IEnumerator PutHatOn() // 모자
    {
        isFound = true;
        hat.SetActive(true);
        yield return new WaitForSeconds(2.0f);
    }
}
