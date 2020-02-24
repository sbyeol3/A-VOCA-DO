using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1MoveBoa : MonoBehaviour
{
    public Transform target;
    private float speed = 10.0f;
    private Vector3 tarPos = new Vector3(0.27f, 0.18f, -0.03f);
    private Vector3 closet = new Vector3(0.273f, 0.18f, -0.16f);

    private AudioSource audioFile;
    public AudioClip talking1Sound; // 보아가 말하는 소리


    void Awake()
    {
        target.transform.position = new Vector3(-0.28f, 0.18f, -0.03f); // pos 초기화
    }

    void Start()
    {

       
    }

    void Update()
    {
        
    }

    public IEnumerator InitBoa()
    {
        this.audioFile = this.gameObject.AddComponent<AudioSource>();
        this.audioFile.clip = this.talking1Sound;
        this.audioFile.loop = false;

        transform.position = Vector3.Lerp(transform.position, tarPos, speed * Time.deltaTime);
        Debug.Log("AWAKE");
        StartCoroutine("MoveToCloset");
        yield return new WaitForSeconds(0.1f);
    }

    public IEnumerator MoveToCloset() // 신발장으로 이동
    {
        Debug.Log("Move");
        transform.position = Vector3.Lerp(transform.position, closet, speed * Time.deltaTime);
        this.audioFile.Play();
        yield return new WaitForSeconds(0.1f);
    }
}
