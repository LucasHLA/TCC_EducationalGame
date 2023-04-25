using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    public bool isFlipped = false;
    public float maxRange;
    public LayerMask layer;
    private Rigidbody2D rb;
    public int lives; 

    [Header("Distances")]
    [SerializeField] private float wakeDistance;
    [SerializeField] private float idleDistance;
    [SerializeField] private float walkDistance;

    [Header("Boss Colliders")]
    public GameObject leftCollider;
    public GameObject rightCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    public void PlayerDirection()
    {
        Vector3 flip = transform.localScale;

        flip.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f,0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flip;
            transform.Rotate(0f,180f,0f);
            isFlipped = true;
        }
    }

    private void FixedUpdate()
    {
        WakeUp();
    }
    void WakeUp()
    {
        Collider2D area = Physics2D.OverlapCircle(transform.position, maxRange,layer);

        if(area != null)
        {
            if (area.CompareTag("Player"))
            {
                float distance = Vector2.Distance(player.position, rb.position);
                if ( distance <= wakeDistance)
                {
                    leftCollider.SetActive(true);
                    rightCollider.SetActive(true);
                    anim.SetInteger("state", 1);
                    if(distance <= idleDistance)
                    {
                        anim.SetInteger("state", 2);
                        if(distance <= walkDistance)
                        {
                            anim.SetInteger("state", 3);
                        }
                    }
                    
                }
            }
        }
    }

    void jumpedOn()
    {
        lives--;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxRange);
    }
}
