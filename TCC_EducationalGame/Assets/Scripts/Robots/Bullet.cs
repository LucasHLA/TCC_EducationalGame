using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed;

        Destroy(this.gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //here comes any hit that the bullet takes or collide with
    }
}
