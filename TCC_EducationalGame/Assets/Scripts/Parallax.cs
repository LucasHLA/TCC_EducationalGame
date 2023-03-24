using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float length;
    public float startPos;

    public Transform cam;

    public float parallaxEffect;
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float rePos = cam.transform.position.x * (1 - parallaxEffect);
        float distance = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPos - distance, transform.position.y, transform.position.z);

        if(rePos < startPos - length)
        {
            startPos += length;
        }
        else if(rePos > startPos - length)
        {
            startPos -= length;
        }
    }
}
