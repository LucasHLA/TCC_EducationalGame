using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear_Claw : MonoBehaviour
{
    public Vector3 attackOffset;
    public float attackRange;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;

        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D hit = Physics2D.OverlapCircle(pos, attackRange,attackMask);

        if (hit != null)
        {
            hit.GetComponent<Player>().TakeDamage();
            hit.GetComponent<Player>().health--;

            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health < 0)
            {
                GameObject.FindObjectOfType<GameController>().GetComponent<GameController>().ShowGameOver();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }

    public void PlayBearAttackSound()
    {
        GameObject.FindObjectOfType<Bear>().PlayAttackSound();
    }
}
