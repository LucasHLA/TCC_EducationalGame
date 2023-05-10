using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * -speed;

        Destroy(this.gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Barrier"))
        {
            Destroy(this.gameObject,0.1f);
        }

        if (other.transform.CompareTag("Robot"))
        {
            Destroy(this.gameObject, 0.1f);
            GameObject.FindGameObjectWithTag("Robot").GetComponent<TankerRobot>().Damage();
        }
    }
}
