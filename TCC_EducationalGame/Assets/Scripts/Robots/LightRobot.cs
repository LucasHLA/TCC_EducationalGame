using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRobot : Robot
{
    [SerializeField] private bool isOn;

    public LayerMask ground;
    private Collider2D col;
    [SerializeField] private float jumpForce;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    protected override void Update()
    {
        base.Update();
        LightUP();
        Jump();
    }

    private void FixedUpdate()
    {
        LightMoviment();
    }

    protected void LightMoviment()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal > 0)
        {
            state = State.Walk;
            if (usingSpecial)
            {
                state = State.Special;
            }
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontal < 0)
        {
            state = State.Walk;
            if (usingSpecial)
            {
                state = State.Special;
            }
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (horizontal == 0 && rb.velocity.y == 0f)
        {
            state = State.Idle;
            if (usingSpecial)
            {
                state = State.Special;
            }
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && col.IsTouchingLayers(ground))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void LightUP()
    {
        if (usingSpecial)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                usingSpecial = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                usingSpecial = true;
            }
        }
    }
}
