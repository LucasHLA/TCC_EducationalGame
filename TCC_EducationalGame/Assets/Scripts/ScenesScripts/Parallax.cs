using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float moveSpeed = 2.0f;  
    public float initialXPosition;  

    void Start()
    {
        
        initialXPosition = transform.position.x;
    }

    void Update()
    {
        
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        
        if (transform.position.x <= -311)
        {
            
            transform.position = new Vector3(initialXPosition, transform.position.y, transform.position.z);
        }
    }
}
