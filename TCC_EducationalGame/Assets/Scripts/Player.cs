using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Basic Settings")]
    private Rigidbody2D rb;
    private Collider2D col;
    [SerializeField] private int health;
    [SerializeField] private float speed;

    [Header("State Machine")]
    private Animator anim;
    [SerializeField] private enum State {Idle, Walk, Jump};
    private State state = State.Idle;

    [Header("Jumping related")]
    [SerializeField] private LayerMask ground;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isJumping;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        anim.SetInteger("State", (int)state);
    }
    private void FixedUpdate()
    {
        BaseMovement();
    }

    private void BaseMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if( horizontal > 0)
        {
            state = State.Walk;
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else if( horizontal < 0)
        {
            state = State.Walk;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if(horizontal == 0 && rb.velocity.y == 0f)
        {
            state = State.Idle;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && col.IsTouchingLayers(ground))
        {
                state = State.Jump;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if(rb.velocity.y > 0.01f)
        {
            state = State.Jump;        
        }
    }
}
