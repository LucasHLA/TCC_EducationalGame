using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapRobot : Robot
{
    [Header("Attacking Related")]
    private bool isAttacking;
    [SerializeField] private Transform attackingPoint;
    [SerializeField] private float radius;
    public AudioClip punchSound;
    public AudioClip walkSound;

    protected override void Update()
    {
        base.Update();
        Attack();
    }

    private void FixedUpdate()
    {
        CapMoviment();
    }

    private void CapMoviment()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal > 0)
        {
            if (!isAttacking)
            {
                state = State.Walk;
            }

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontal < 0)
        {
            if (!isAttacking)
            {
                state = State.Walk;
            }

            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (horizontal == 0 && rb.velocity.y == 0f && !isAttacking)
        {
           state = State.Idle;
        }
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isAttacking)
        {
            isAttacking = true;
            state = State.Special;
            audioSource.PlayOneShot(punchSound);
            Collider2D hit = Physics2D.OverlapCircle(attackingPoint.position, radius);

            if (hit != null)
            {
                if (hit.CompareTag("Brick"))
                {
                    hit.gameObject.GetComponent<Animator>().SetTrigger("Destroy");
                    Destroy(hit.gameObject,0.4f);
                }
                if (hit.CompareTag("Crab"))
                {
                    GameObject.FindObjectOfType<Crab>().GetComponent<Crab>().Defeated();
                    Destroy(hit.gameObject, 3.5f);
                }
                if (hit.CompareTag("Claw"))
                {
                    Destroy(hit.gameObject, 0.4f);
                }
            }

            StartCoroutine(OnAttack());
        }

    }

    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(0.28f);
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackingPoint.position, radius);
    }

    public void PlayWalkSound()
    {
        audioSource.PlayOneShot(walkSound);
    }
}
