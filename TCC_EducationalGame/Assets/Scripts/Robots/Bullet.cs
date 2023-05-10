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
        if (other.CompareTag("IceBlock"))
        {
            GameObject.FindGameObjectWithTag("IceBlock").GetComponent<IceBlocks>().health--;
            Destroy(this.gameObject,0.1f);
        }

        if (other.gameObject.layer == 3)
        {
            Destroy(this.gameObject, 0.1f);
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject, 0.1f);
            GameObject.FindObjectOfType<IceEnemyController>().GetComponent<IceEnemyController>().health--;
        }

        if (other.CompareTag("SnowGolem"))
        {
            Destroy(this.gameObject, 0.1f);
            GameObject.FindGameObjectWithTag("SnowGolem").GetComponent<SnowGolem>().Damage();
        }
    }
}
