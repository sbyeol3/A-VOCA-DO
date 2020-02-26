using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scene5 : MonoBehaviour
{

    public GameObject boa, balloon, house, molly;
    public static bool isBalloonFound, isBgFound, isSettingFinished = false, soundplayed = false, isBalloonOpened = false;
    public Animator walk, molly_walk;
    public AudioClip balloon_sound, thankyou;
    public AudioSource boa_sound;
    public SkinnedMeshRenderer boa_face;
    public Material[] boa_faces;

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

    }

    // Update is called once per frame
    void Update()
    {

        if (isSettingFinished)
        {
            if (isBalloonFound)
            {

                boa_clear();
                if (!isBalloonOpened)
                {
                    StartCoroutine(balloon_open());
                    isBalloonOpened = true;
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
        for (int i = 0; i < 60; i++)
        {
            molly.transform.localPosition = new Vector3(0.014f+i*0.0007f, 0, 0.184f - i*0.0058f);
            Debug.Log(boa.transform.localPosition);
            yield return new WaitForSeconds(0.05f);
        }
        molly_walk.SetBool("isWalk", false);
    }



    public IEnumerator boa_set()
    {

        Debug.Log("setting  ======  setting");
        isSettingFinished = true;
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
        //boa_sound.PlayOneShot(bridge);
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
}
