using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scene5 : MonoBehaviour
{

    public GameObject boa, balloon, house, molly , environment;
    public static bool isBalloonFound, isBgFound, isWrongFound=false, isSettingFinished = false, isSettingStarted = false, soundplayed = false, isBalloonOpened = false, noText;
    public Animator walk, molly_walk;
    public AudioClip balloon_sound, thankyou, molly_sound;
    public AudioSource boa_sound;
    public SkinnedMeshRenderer boa_face;
    public Material[] boa_faces;
    public Text showCard;
    public Button Stop;
    public Image askFinish;
    // Start is called before the first frame update



    void Start()
    {

        boa_face.material = boa_faces[0];
        molly.SetActive(false);
        boa.transform.rotation = Quaternion.Euler(0, 0, 0);
        walk.SetBool("isWalk", false);
        boa.SetActive(false);
        balloon.SetActive(false);
        house.SetActive(false);
        environment.SetActive(false);
        showCard.gameObject.SetActive(false);
        Stop.gameObject.SetActive(false);
        askFinish.gameObject.SetActive(false);
        isBalloonFound = false;
        isBgFound = false;
        isSettingFinished = false;
        isSettingStarted = false;
        soundplayed = false;
        isBalloonOpened = false;
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
            if (isBalloonFound)
            {
                showCard.gameObject.SetActive(false);
                boa_clear();
                if (!isBalloonOpened)
                {
                    StartCoroutine(balloon_open());
                    isBalloonOpened = true;
                }
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
    
    public IEnumerator balloon_open()
    {

        walk.SetBool("isWalk", false);
        walk.SetBool("isSuccess", true);
        isBalloonOpened = true;
        yield return new WaitForSeconds(3f);
        walk.SetBool("isSuccess", false);
        balloon.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(molly_set());
    }

    public IEnumerator molly_set()
    {
        molly.transform.localPosition = new Vector3(0.014f, 0, 0.184f);
        molly.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        molly_walk.SetBool("isWalk", true);
        boa_sound.PlayOneShot(molly_sound);
        for (int i = 0; i < 60; i++)
        {
            molly.transform.localPosition = new Vector3(0.014f+i*0.0007f, 0, 0.184f - i*0.0058f);
            Debug.Log(boa.transform.localPosition);
            yield return new WaitForSeconds(0.05f);
        }
        molly_walk.SetBool("isWalk", false);
        yield return new WaitForSeconds(8f);
        finished();     //끝!
    }



    public IEnumerator boa_set()
    {

        Debug.Log("setting  ======  setting");
        isSettingStarted = true;
        environment.SetActive(true);
        boa.SetActive(true);
        house.SetActive(true);
        boa.transform.localPosition = new Vector3(-0.118f, 0, -0.347f);
        walk.SetBool("isWalk", true);
        for (int i = 0; i < 20; i++)
        {
            boa.transform.localPosition = new Vector3(-0.118f, 0, -0.347f + i * 0.01f);
            yield return new WaitForSeconds(0.2f);
        }
        walk.SetBool("isWalk", false);
        //여기서 놀라야하는데
        for (int i = 0; i < 10; i++)
        {
            boa.transform.rotation = Quaternion.Euler(0, 18 * (i + 1), 0);
            yield return new WaitForSeconds(0.05f);
        }
        isSettingFinished = true;
        boa_sound.PlayOneShot(balloon_sound);
    }

    public void boa_clear()
    {
        
        boa_face.material = boa_faces[1];
        boa.SetActive(true);
        if (!soundplayed)
        {
            boa_sound.PlayOneShot(thankyou);
            soundplayed = true;
        }
    }

    public void finished()
    {
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
