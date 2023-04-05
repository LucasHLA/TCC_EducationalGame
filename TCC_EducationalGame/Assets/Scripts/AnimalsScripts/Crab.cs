using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    [Header("Position and Walking related")]
    [SerializeField] private float position;
    [SerializeField] private Transform visionPoint;
    [SerializeField] private float maxVision;
    [SerializeField] private float stopDistance;
    [SerializeField] private float speed;
    [SerializeField] private float pushForce;
    private Rigidbody2D rb;
    private Animator anim;
    void Start()
    {
        position = transform.position.x;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        GetPlayer();
    }

    void GetPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(visionPoint.position,Vector2.left,maxVision);

        if(hit != null)
        {
            if (hit.transform.CompareTag("Robot"))
            {
                transform.eulerAngles = new Vector2(0, 0);
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                float distance = Vector2.Distance(transform.position, hit.transform.position);

                if (distance <= stopDistance)
                {
                    speed = 0;
                    anim.SetTrigger("atk");
                    Rigidbody2D playerRigidbody = hit.transform.GetComponent<Rigidbody2D>();
                    playerRigidbody.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
                    
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(visionPoint.position, Vector2.left * maxVision);
    }
}
