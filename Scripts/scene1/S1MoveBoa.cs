using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1MoveBoa : MonoBehaviour
{
    public Transform target;
    public GameObject boa;
    private float speed = 2.0f;
    //private Vector3 tarPos = new Vector3(0.32f, 0.1f, -0.16f);
    private Vector3 closet = new Vector3(0.273f, 0.18f, -0.16f);

    private AudioSource audioFile;
    public AudioClip talking1Sound; // 보아가 말하는 소리


    void Awake()
    {
        
    }

    void Start()
    {

       
    }

    void Update()
    {

    }

    public IEnumerator InitBoa()
    {
        boa.SetActive(true);
        target.transform.localPosition = new Vector3(-0.3f, 0.068f, 0.13f); // pos 초기화
        Debug.Log("초기화");
        Debug.Log(boa.transform.localPosition);
        this.audioFile = this.gameObject.AddComponent<AudioSource>();
        this.audioFile.clip = this.talking1Sound;
        this.audioFile.loop = false;

        //Vector3 tarPos = boa.transform.localPosition + new Vector3(1.0f, 0, -0.2f);
        for(int i = 0;i < 20; i++){
            boa.transform.localPosition = boa.transform.localPosition + new Vector3(0.03f, 0, -0.005f);
            Debug.Log(boa.transform.localPosition);
            yield return new WaitForSeconds(0.2f);
        }
        //transform.localPosition = Vector3.Lerp(transform.position, tarPos, speed * Time.deltaTime);
        Debug.Log(boa.transform.localPosition);
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator MoveToCloset() // 신발장으로 이동
    {
        Debug.Log("코루틴 Move");
        //transform.localPosition = Vector3.Lerp(transform.position, closet, speed * Time.deltaTime);
        this.audioFile.Play();
        yield return new WaitForSeconds(2.0f);
    }
}
