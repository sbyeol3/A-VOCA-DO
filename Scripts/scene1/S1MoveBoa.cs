using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1MoveBoa : MonoBehaviour
{
    public Transform target;
    private float speed = 10.0f;
    private Vector3 tarPos = new Vector3(0.31f, -1.14f, -0.55f);
    private Vector3 closet = new Vector3(0.22f, 0.18f, -0.55f);

    private AudioSource audio;
    public AudioClip talking1Sound; // 보아가 말하는 소리


    void Awake()
    {
        target.transform.position = new Vector3(-1.29f, -1.36f, -0.55f); // pos 초기화
    }

    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.talking1Sound;
        this.audio.loop = false;

        transform.position = Vector3.Lerp(transform.position, tarPos, speed * Time.deltaTime);
        Debug.Log("AWAKE");
        StartCoroutine("MoveToCloset");
    }

    void Update()
    {
        
    }

    IEnumerator MoveToCloset() // 신발장으로 이동
    {
        transform.position = Vector3.Lerp(transform.position, closet, speed * Time.deltaTime);
        this.audio.Play();
        yield return new WaitForSeconds(0.1f);
    }
}
