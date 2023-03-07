using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRobot : Robot
{
    [SerializeField] private bool isOn;
    protected override void Update()
    {
        base.Update();
        LightUP();
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
