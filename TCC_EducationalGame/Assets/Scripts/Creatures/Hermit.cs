using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hermit : MonoBehaviour
{
    [Header("Movement and hiding")]
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private float speed;
    [SerializeField] private float startSpeed;
    [SerializeField] private float maxRadius;
    [SerializeField] private float restingTime;

    [Header("Basic settings")]
    private Animator anim;
    private Collider2D col;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask ground;
    [SerializeField] private bool facingLeft = false;

    void Start()
    {
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        startSpeed = speed;
    }

    void Update()
    {
        Move();
        
    }

    private void FixedUpdate()
    {
        Hide();
    }

    void Move()
    {
        if (!facingLeft)
        {
            if(transform.position.x < rightCap)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                rb.velocity = new Vector2(speed, rb.velocity.y);
                anim.SetInteger("State", 1);
            }

            if (transform.position.x >= rightCap)
            {
                restingTime += Time.deltaTime;
                rb.velocity = Vector2.zero;
                anim.SetInteger("State", 0);

                if(restingTime >= 3f)
                {
                    restingTime = 0;
                    facingLeft = true;
                }
            }
        }
        else
        {
            if (transform.position.x > leftCap)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                anim.SetInteger("State", 1);
            }

            if (transform.position.x <= leftCap)
            {
                restingTime += Time.deltaTime;
                rb.velocity = Vector2.zero;
                anim.SetInteger("State", 0);

                if (restingTime >= 3f)
                {
                    restingTime = 0;
                    facingLeft = false;
                }
            }
        }
    }

    void Hide()
    {
        Collider2D area = Physics2D.OverlapCircle(transform.position, maxRadius);

        if(area != null)
        {
            if (area.CompareTag("Player"))
            {
                anim.SetBool("isHiding",true);
                rb.velocity = Vector2.zero;
            }
            else
            {
                anim.SetBool("isHiding", false);
                Move();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxRadius);
    }
}