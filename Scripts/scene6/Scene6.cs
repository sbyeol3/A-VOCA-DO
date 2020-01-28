using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene6 : MonoBehaviour
{
    public GameObject boa;
    // Start is called before the first frame update
    void Start()
    {
        boa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator boa_set()
    {
        Debug.Log("boa_set activate");
        boa.SetActive(true);
        boa.transform.localPosition = new Vector3(-0.4f,-0.0636f,0);
        for (int i = 0; i < 10; i++)
        {
            boa.transform.localPosition = new Vector3((-0.4f+i*0.02f), -0.0636f, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
