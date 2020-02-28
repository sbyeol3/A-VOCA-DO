using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene6 : MonoBehaviour
{
    public GameObject boa, bridge, environment;
    public static bool isBridgeFound, isBgFound, isSettingFinished = false, soundplayed =false, isClearFinished = false;
    public Animator walk;
    public AudioClip bridgeSound, thankyou;
    public AudioSource boa_sound;
    // Start is called before the first frame update


    
    void Start()
    {
        walk.SetBool("isWalk", false);
        boa.SetActive(false);
        bridge.SetActive(false);
        environment.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (isSettingFinished)
        {
            if (isBridgeFound && !isClearFinished)
            {
                StartCoroutine(boa_clear());
                isClearFinished = true;
            }
        }
        else
        {
            if (isBgFound)
            {
                StartCoroutine(boa_set());
             
            }
        }
        
        
    }

    public IEnumerator boa_set()
    {
        
        Debug.Log("setting  ======  setting");
        isSettingFinished = true;
        boa.SetActive(true);
        environment.SetActive(true);
        boa.transform.localPosition = new Vector3(-0.4f,-0.0636f,0);
        walk.SetBool("isWalk", true);
        for (int i = 0; i < 10; i++)
        {
            boa.transform.localPosition = new Vector3((-0.4f+i*0.015f), -0.0636f, 0);
            yield return new WaitForSeconds(0.2f);
        }
        walk.SetBool("isWalk", false);
        for (int i = 0; i < 5; i++)
        {
            boa.transform.rotation = Quaternion.Euler(0, 90 + 18 * (i + 1), 0);
            yield return new WaitForSeconds(0.1f);
        }
        boa_sound.PlayOneShot(bridgeSound);
    }

    public IEnumerator boa_clear()
    {
        isClearFinished = true;
        yield return new WaitForSeconds(0.5f);
        walk.SetBool("isSuccess", true);
        bridge.SetActive(true);
        boa.SetActive(true);
        if (!soundplayed)
        {
            boa_sound.PlayOneShot(thankyou);
            soundplayed = true;
        }
        yield return new WaitForSeconds(3f);
        walk.SetBool("isSuccess", false);
        for (int i = 0; i < 5; i++)
        {
            boa.transform.rotation = Quaternion.Euler(0, 180 - 18 * (i + 1), 0);
            yield return new WaitForSeconds(0.1f);
        }
        walk.SetBool("isWalk", true);
        for (int i = 0; i < 5; i++)
        {
            boa.transform.localPosition = boa.transform.localPosition + new Vector3(0.01f, 0.015f, 0);
            yield return new WaitForSeconds(0.07f);
        }
        for ( int i=0; i<15; i++)
        {
            boa.transform.localPosition = boa.transform.localPosition + new Vector3(0.015f,0.007f,0);
            yield return new WaitForSeconds(0.07f);
        }
        
        for (int i = 0; i < 15; i++)
        {
            boa.transform.localPosition = boa.transform.localPosition + new Vector3(0.015f, -0.007f, 0);
            yield return new WaitForSeconds(0.07f);
        }
        for (int i = 0; i < 5; i++)
        {
            boa.transform.localPosition = boa.transform.localPosition + new Vector3(0.01f, -0.015f, 0);
            yield return new WaitForSeconds(0.07f);
        }
        for (int i = 0; i < 15; i++)
        {
            boa.transform.localPosition = boa.transform.localPosition + new Vector3(0.015f, 0, 0);
            yield return new WaitForSeconds(0.07f);
        }
        walk.SetBool("isWalk", false);
        
    }
}
