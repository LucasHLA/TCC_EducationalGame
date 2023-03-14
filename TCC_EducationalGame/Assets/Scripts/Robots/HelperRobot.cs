using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperRobot : Robot
{

    protected override void Update()
    {
        base.Update();
        HelperMoviment();
    }

    protected void HelperMoviment()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal > 0)
        {
            state = State.Walk;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontal < 0)
        {
            state = State.Walk;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (horizontal == 0 && rb.velocity.y == 0f)
        {
            state = State.Idle;
        }
    }
}
