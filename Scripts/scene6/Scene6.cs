using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene6 : MonoBehaviour
{
    public GameObject boa;
    public static bool isBridgeFound, isBgFound, isSettingFinished = false, soundplayed =false;
    public Animator walk;
    public AudioClip bridge, thankyou;
    public AudioSource boa_sound;
    // Start is called before the first frame update


    
    void Start()
    {
        walk.SetBool("isWalk", false);
        boa.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (isSettingFinished)
        {
            if (isBridgeFound)
            {
                boa_clear();
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
        boa.transform.localPosition = new Vector3(-0.4f,-0.0636f,0);
        walk.SetBool("isWalk", true);
        for (int i = 0; i < 10; i++)
        {
            boa.transform.localPosition = new Vector3((-0.4f+i*0.02f), -0.0636f, 0);
            yield return new WaitForSeconds(0.2f);
        }
        walk.SetBool("isWalk", false);
        boa_sound.PlayOneShot(bridge);
    }

    public void boa_clear()
    {
        boa.SetActive(true);
        if (!soundplayed)
        {
            boa_sound.PlayOneShot(thankyou);
            soundplayed = true;
        }
        walk.SetBool("isWalk", true);
        boa.transform.localPosition += Vector3.right * Time.deltaTime*0.1f;

    }
}
