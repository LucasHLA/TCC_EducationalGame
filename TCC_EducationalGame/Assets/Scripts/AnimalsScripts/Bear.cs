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
    public GameObject letterDrop;

    [SerializeField] private float pushForce;
    [SerializeField] private float spinForce;

    [Header("Distances")]
    [SerializeField] private float wakeDistance;
    [SerializeField] private float idleDistance;
    [SerializeField] private float walkDistance;

    [Header("Boss Colliders")]
    public GameObject leftCollider;
    public GameObject rightCollider;
    private BoxCollider2D col2D;
    public BoxCollider2D hitCol2D;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Defeated();
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

    public void jumpedOn()
    {
        if(lives >= 0)
        {
            lives--;
        }
    }

    void Defeated()
    {
        if (lives <= 0)
        {
            anim.SetInteger("state", 2);
            rb.velocity = new Vector3(rb.velocity.x, pushForce, spinForce);
            col2D.enabled = false;
            hitCol2D.enabled = false;
            StartCoroutine(DestroyAfterDefeated());
            GameObject.FindObjectOfType<BossSceneLogic>().isDestroyed = true;
            letterDrop.SetActive(true);
        }
    }
    IEnumerator DestroyAfterDefeated()
    {
        yield return new WaitForSeconds(1.7f);
        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxRange);
    }
}
