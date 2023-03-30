using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapRobot : Robot
{
    [Header("Attacking Related")]
    private bool isAttacking;
    [SerializeField] private Transform attackingPoint;
    [SerializeField] private float radius;

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
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;
            state = State.Special;

            Collider2D hit = Physics2D.OverlapCircle(attackingPoint.position, radius);

            if (hit != null)
            {

                if (hit.CompareTag("Brick"))
                {
                    hit.gameObject.GetComponent<Animator>().SetTrigger("Destroy");
                    Destroy(hit.gameObject,0.4f);
                }

                /*If we want to make this robot to kill enemies we need to make another "if" 
                 checking if the collider "hit" is colliding with the enemy and call the "enemy hit" method
                 to make it suffer dmg and eventually be killed*/
                
                
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
}
