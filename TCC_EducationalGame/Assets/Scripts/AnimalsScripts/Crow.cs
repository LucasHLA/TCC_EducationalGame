using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float waitingTime;
    [SerializeField] private float RightCap;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Flying());
    }

    void Update()
    {
        if(transform.position.x > RightCap)
        {
            Destroy(this.gameObject, 1f);
        }
    }

    IEnumerator Flying()
    {
        yield return new WaitForSeconds(waitingTime);

        if(transform.position.x <= RightCap)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        
    }
}
