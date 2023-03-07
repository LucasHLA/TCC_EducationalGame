using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerRobot : Robot
{
    [Header("Shooting Related")]
    private bool isShooting;

    [Header("Bullet related")]
    public GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    protected override void Update()
    {
        base.Update();
        Shooting();
    }

    private void FixedUpdate()
    {
        TankerMovement();
    }

    private void TankerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal > 0)
        {
            if (!isShooting)
            {
                state = State.Walk;
            }

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontal < 0)
        {
            if (!isShooting)
            {
                state = State.Walk;
            }
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (horizontal == 0 && rb.velocity.y == 0f && !isShooting)
        {
            state = State.Idle;
        }
    }

    private void Shooting()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            state = State.Special;
            isShooting = true;
            StartCoroutine(OnShooting());
            StartCoroutine(AfterShooting());
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator OnShooting()
    {
        yield return new WaitForSeconds(.2f);
        Shoot();
    }

    IEnumerator AfterShooting()
    {
        yield return new WaitForSeconds(.4f);
        isShooting = false;
    }
}

