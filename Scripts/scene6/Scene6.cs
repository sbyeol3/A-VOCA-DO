using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene6 : MonoBehaviour
{
    public GameObject boa, bridge, environment;
    public static bool isBridgeFound, isBgFound, isWrongFound = false, isSettingStarted = false, isSettingFinished = false, soundplayed =false, isClearFinished = false, noText;
    public Animator walk;
    public AudioClip bridgeSound, thankyou;
    public AudioSource boa_sound;
    public Text showCard;
    public Button Next, Stop;
    public Image askFinish;
    // Start is called before the first frame update



    void Start()
    {
        walk.SetBool("isWalk", false);
        boa.SetActive(false);
        bridge.SetActive(false);
        environment.SetActive(false);
        Next.gameObject.SetActive(false);
        Stop.gameObject.SetActive(false);
        showCard.gameObject.SetActive(false);
        askFinish.gameObject.SetActive(false);
        isBridgeFound = false;
        isBgFound = false;
        isSettingStarted = false;
        isSettingFinished = false;
        soundplayed = false;
        isClearFinished = false;
        noText = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (noText)
        {
            showCard.gameObject.SetActive(false);
        }
        if (isSettingStarted)
        {
            if (isClearFinished)
            {
                showCard.gameObject.SetActive(false);
            }
            if (isBridgeFound && !isClearFinished)
            {
                showCard.gameObject.SetActive(false);
                StartCoroutine(boa_clear());
                isClearFinished = true;
            }
            else
            {
                if (isWrongFound)
                {
                    showCard.gameObject.SetActive(false);
                }
                else
                {
                    if (isSettingFinished)
                    {
                        showCard.gameObject.SetActive(true);
                    }
                }
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
        isSettingStarted = true;
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
        isSettingFinished = true;
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
        finished();
        
    }
    public void finished()
    {
        Next.gameObject.SetActive(true);
        Stop.gameObject.SetActive(true);
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
