using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    [Header ("Hopping Related")]
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private float jumpLength;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float restingTime;

    [Header("Basic settings")]
    private Animator anim;
    private Collider2D col;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask ground;
    [SerializeField]private bool facingLeft = false;


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!facingLeft)
        {
            if(transform.position.x < rightCap && col.IsTouchingLayers(ground))
            {
                transform.eulerAngles = new Vector3(0f,0f,0f);
                rb.velocity = new Vector2(jumpLength, jumpHeight);
                anim.SetInteger("State", 1);
            }

            else if(transform.position.x >= rightCap)
            {
                restingTime += Time.deltaTime;
                anim.SetInteger("State", 0);
                if (restingTime >= 3)
                {
                    facingLeft = true;
                    restingTime = 0;
                }
            }
            
        }
        else
        {
            if (transform.position.x > leftCap && col.IsTouchingLayers(ground))
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                rb.velocity = new Vector2(-jumpLength, jumpHeight);
                anim.SetInteger("State", 1);
            }

            else if (transform.position.x <= leftCap)
            {
                restingTime += Time.deltaTime;
                anim.SetInteger("State", 0);
                if (restingTime >= 3f)
                {
                    facingLeft = false;
                    restingTime = 0;
                }
            }
        }       
    }
}
