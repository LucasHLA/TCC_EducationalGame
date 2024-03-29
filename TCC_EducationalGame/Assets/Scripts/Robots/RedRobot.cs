using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRobot : Robot
{
    public AudioClip crouchSong;

    protected override void Update()
    {
        base.Update();
        Crouch();
    }

    private void FixedUpdate()
    {
        RedMoviment();
    }

    void RedMoviment()
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

    void Crouch()
    {
        if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W)) && !usingSpecial)
        {
            audioSource.PlayOneShot(crouchSong);
            usingSpecial = true;
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow) && usingSpecial && !insideTheTunnel)
        {
            audioSource.PlayOneShot(crouchSong);
            usingSpecial = false;
        }
    }
}
