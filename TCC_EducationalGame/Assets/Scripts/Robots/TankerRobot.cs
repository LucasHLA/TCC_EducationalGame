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

    [Header("Basic Settings")]
    public int health;
    public int initialHealth;
    public float flashDuration = 0.2f;
    public float flashRate = 0.1f;
    public Vector3 respawnPoint;
    private  SpriteRenderer sr;

    [Header("Flash related")]
    private bool isFlashing = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        initialHealth = health;
        respawnPoint = transform.position;
    }
    protected override void Update()
    {
        base.Update();
        Shooting();
        Destroyed();
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

    public void Damage()
    {
        TakeDamage();
        if (health >= 0)
        {
            health--;
        }
    }

    public void TakeDamage()
    {
        if (!isFlashing)
        {
            isFlashing = true;
            InvokeRepeating("FlashTanker", 0f, flashRate);
            Invoke("StopFlashing", flashDuration);
        }
    }

    private void FlashTanker()
    {
        sr.enabled = !sr.enabled;
    }

    private void StopFlashing()
    {
        isFlashing = false;
        sr.enabled = true;
        CancelInvoke("FlashTanker");
    }

    private void Destroyed()
    {
        if(health < 0)
        {
            transform.position = respawnPoint;
            GameObject.FindObjectOfType<PlayerSwitch>().GetComponent<PlayerSwitch>().SwitchPlayer();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health--;
            health = initialHealth;
        }
    }
}

