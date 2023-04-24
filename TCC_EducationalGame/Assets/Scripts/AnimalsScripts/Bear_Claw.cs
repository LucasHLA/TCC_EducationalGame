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
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
