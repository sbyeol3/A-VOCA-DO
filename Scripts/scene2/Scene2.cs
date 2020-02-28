using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.RainMaker
{
    public class Scene2 : MonoBehaviour
    {

        public GameObject boa ,umbrella, environment;
        public static bool isUmbrellaFound, isBgFound, isSettingFinished = false, soundplayed = false, isUmbrellaOpened = false;
        public Animator walk;
        public AudioClip unbrella, thankyou;
        public AudioSource boa_sound;
        public SkinnedMeshRenderer boa_face;
        public Material[] boa_faces;
        public RainScript Rainscript;
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

        }

        // Update is called once per frame
        void Update()
        {

            if (isSettingFinished)
            {
                if (isUmbrellaFound)
                {

                    boa_clear();
                    if (!isUmbrellaOpened)
                    {
                        StartCoroutine(umbrella_open());
                        isUmbrellaOpened = true;
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
        }



        public IEnumerator boa_set()
        {

            Debug.Log("setting  ======  setting");
            isSettingFinished = true;
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
            for (int i = 0; i < 5; i++)
            {
                boa.transform.rotation = Quaternion.Euler(0, 90 + 18 * (i + 1), 0);
                yield return new WaitForSeconds(0.1f);
            }
            boa_face.material = boa_faces[1];
            //boa_sound.PlayOneShot(bridge);
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
    }
}