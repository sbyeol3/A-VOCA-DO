using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DigitalRuby.RainMaker
{
    public class Scene2 : MonoBehaviour
    {

        public GameObject boa ,umbrella, environment;
        public static bool isUmbrellaFound , isBgFound, isWrongFound = false, isSettingStarted = false, isSettingFinished = false, soundplayed = false, isUmbrellaOpened, noText;
        public Animator walk;
        public AudioClip unbrella, thankyou;
        public AudioSource boa_sound;
        public SkinnedMeshRenderer boa_face;
        public Material[] boa_faces;
        public RainScript Rainscript;
        public Text showCard;
        public Button Next, Stop;
        public Image askFinish;
        // Start is called before the first frame update



        void Start()
        {
            boa_face.material = boa_faces[0];
            Rainscript.RainIntensity = 0;
            boa.transform.rotation = Quaternion.Euler(0, 90, 0);
            walk.SetBool("isWalk", false);
            boa.SetActive(false);
            umbrella.SetActive(false);
            environment.SetActive(false);
            showCard.gameObject.SetActive(false);
            Next.gameObject.SetActive(false);
            Stop.gameObject.SetActive(false);
            askFinish.gameObject.SetActive(false);
            isUmbrellaFound = false;
            isBgFound = false;
            isSettingStarted = false;
            isSettingFinished = false;
            soundplayed = false;
            isUmbrellaOpened = false;
            noText = false;

        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(noText);
            if (noText)
            {
                showCard.gameObject.SetActive(false);
            }
            if (isSettingStarted)
            {
                if (isUmbrellaFound)
                {
                    showCard.gameObject.SetActive(false);
                    boa_clear();
                    if (!isUmbrellaOpened)
                    {
                        StartCoroutine(umbrella_open());
                        isUmbrellaOpened = true;
                    }
                    else
                    {
                        showCard.gameObject.SetActive(false);
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
                    StartCoroutine(raining());
                }
            }


        }
        public IEnumerator raining()
        {
            for (int i = 0; i < 20; i++)
            {
                Rainscript.RainIntensity = i * 0.015f;
                yield return new WaitForSeconds(0.2f);
            }
        }

        public IEnumerator umbrella_open()
        {
            isUmbrellaOpened = true;
            for (int i = 0; i < 5; i++)
            {
                umbrella.transform.localScale = new Vector3(0 + 0.025f * (i + 1), 0 + 0.025f * (i + 1), 0 + 0.025f * (i + 1));
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(5f);
            finished();
        }



        public IEnumerator boa_set()
        {
            isSettingStarted = true;
            Debug.Log("setting  ======  setting");
            environment.SetActive(true);
            boa.SetActive(true);
            boa.transform.localPosition = new Vector3(-0.4f, -0.0636f, 0);
            walk.SetBool("isWalk", true);
            for (int i = 0; i < 20; i++)
            {
                boa.transform.localPosition = new Vector3((-0.4f + i * 0.02f), -0.0636f, 0);
                yield return new WaitForSeconds(0.2f);
            }
            walk.SetBool("isWalk", false);
            //여기서 놀라야하는데
            boa_sound.PlayOneShot(unbrella);
            for (int i = 0; i < 5; i++)
            {
                boa.transform.rotation = Quaternion.Euler(0, 90 + 18 * (i + 1), 0);
                yield return new WaitForSeconds(0.1f);
            }
            boa_face.material = boa_faces[1];
            isSettingFinished = true;
        }

        public void boa_clear()
        {

            umbrella.SetActive(true);
            boa_face.material = boa_faces[2];
            boa.SetActive(true);
            if (!soundplayed)
            {
                boa_sound.PlayOneShot(thankyou);
                soundplayed = true;
            }
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

   
}