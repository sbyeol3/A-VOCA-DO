using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1MoveBoa : MonoBehaviour
{
    public Transform target;
    public GameObject boa;
    public Animator walk;

    private AudioSource audioFile;
<<<<<<< HEAD
    public bool isSet = true;
    public bool isFound = false;
    public GameObject hat;
=======
    public AudioClip talking1Sound; // 보아가 말하는 소리
>>>>>>> f81a3061b4667ec574610a429b4af4e4882a4058


    void Awake()
    {
<<<<<<< HEAD
        hat.SetActive(false);
=======
        
>>>>>>> f81a3061b4667ec574610a429b4af4e4882a4058
    }


    public IEnumerator InitBoa()
    {
        boa.SetActive(true);
<<<<<<< HEAD
        isSet = false;
        target.transform.localPosition = new Vector3(-0.015f, 0.013f, -0.0138f); // pos 초기화
        Debug.Log("초기화");
        Debug.Log(boa.transform.localPosition);
        this.audioFile = this.gameObject.AddComponent<AudioSource>();
        //this.audioFile.clip = this.example;
        this.audioFile.loop = false;

        walk.SetBool("isWalk", true);
        for (int i = 0;i < 95; i++){
=======
        target.transform.localPosition = new Vector3(-0.084f, 0.013f, -0.0138f); // pos 초기화
        Debug.Log("초기화");
        Debug.Log(boa.transform.localPosition);
        this.audioFile = this.gameObject.AddComponent<AudioSource>();
        this.audioFile.clip = this.talking1Sound;
        this.audioFile.loop = false;

        //Vector3 tarPos = boa.transform.localPosition + new Vector3(1.0f, 0, -0.2f);
        // 0.337 0.013 -0.138
        walk.SetBool("isWalk", true);
        for (int i = 0;i < 100; i++){
>>>>>>> f81a3061b4667ec574610a429b4af4e4882a4058
            boa.transform.localPosition = boa.transform.localPosition + new Vector3(0.004f, 0, 0f);
            Debug.Log(boa.transform.localPosition);
            yield return new WaitForSeconds(0.1f);
        }
        walk.SetBool("isWalk", false);
<<<<<<< HEAD
        yield return new WaitForSeconds(3.0f);
        StartCoroutine("Mission");
    }

    public IEnumerator Mission() // 현관으로 이동하기
    {
        this.audioFile.Play(); // 안경을 줘~
        yield return new WaitForSeconds(2.0f);
        
=======
        //transform.localPosition = Vector3.Lerp(transform.position, tarPos, speed * Time.deltaTime);
        Debug.Log(boa.transform.localPosition);
        yield return new WaitForSeconds(2.0f);
        StartCoroutine("MoveToCloset");
    }

    public IEnumerator MoveToCloset() // 신발장으로 이동
    {
        this.audioFile.Play();
        yield return new WaitForSeconds(2.0f);
>>>>>>> f81a3061b4667ec574610a429b4af4e4882a4058
    }

    public IEnumerator PutHatOn() // 모자
    {
        isFound = true;
        hat.SetActive(true);
        yield return new WaitForSeconds(2.0f);
    }
}
