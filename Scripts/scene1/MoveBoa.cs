using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoa : MonoBehaviour
{
    public Transform target;
    private float speed = 10.0f;
    private Vector3 tarPos = new Vector3(0.31f, -1.14f, -0.55f);

    void Awake()
    {
        target.transform.position = new Vector3(-1.29f, -1.36f, -0.55f); // pos 초기화
    }

    void Start()
    {
        transform.position = Vector3.Lerp(transform.position, tarPos, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
