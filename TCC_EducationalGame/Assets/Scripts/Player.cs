using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Basic Settings")]
    private Rigidbody2D rb;
    private Collider2D col;
    public int health;
    [SerializeField] private float speed;
    private SpriteRenderer sr;
    public float flashDuration = 0.2f;
    public float flashRate = 0.1f;
    private bool isFlashing = false;
   
    [Header("State Machine")]
    private Animator anim;
    private enum State { Idle, Walk, Jump, Using };
    private State state = State.Using;
    public bool canUse = false;
    public bool usingPC = false;

    [Header("Jumping related")]
    [SerializeField] private LayerMask ground;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isJumping;
    public bool bossDMG;
    public bool canJump = true;

    [Header("Audio Related")]
    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip runSound;
    public AudioClip collectSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        anim.SetInteger("State", (int)state);
        Jump();

            if (canUse)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    usingPC = true;
                    state = State.Using;
                    GameObject.FindObjectOfType<PlayerSwitch>().GetComponent<PlayerSwitch>().SwitchPlayer();
                }
            }
            else if (!canUse && state != State.Using)
            {

                usingPC = false;
            }
    }
    private void FixedUpdate()
    {
        BaseMovement();
    }
    private void BaseMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        if (horizontal > 0)
        {
            if(col.IsTouchingLayers(ground))
            {
                state = State.Walk;
            }
            
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontal < 0)
        {
            if (col.IsTouchingLayers(ground))
            {
                state = State.Walk;
            }
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (horizontal == 0 && rb.velocity.y == 0f)
        {
            state = State.Idle;
        }
    }

    public void TakeDamage()
    {
        if (!isFlashing)
        {
            isFlashing = true;
            InvokeRepeating("FlashCharacter", 0f, flashRate);
            Invoke("StopFlashing", flashDuration);
        }
    }

    private void FlashCharacter()
    {
        sr.enabled = !sr.enabled;
    }

    private void StopFlashing()
    {
        isFlashing = false;
        sr.enabled = true;
        CancelInvoke("FlashCharacter");
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && col.IsTouchingLayers(ground) && canJump)
        {
            state = State.Jump;
            audioSource.PlayOneShot(jumpSound);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (rb.velocity.y > 0.01f)
        {
            state = State.Jump;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        int letterLayer = LayerMask.NameToLayer("letter");

        if (other.gameObject.layer == letterLayer)
        {
            LetterController.instance.letterTag = other.gameObject.tag.ToString();
            Destroy(other.gameObject);
            LetterController.instance.index++;
            LetterController.instance.countLetters++;
            audioSource.PlayOneShot(collectSound);
        }

        if (other.gameObject.tag == "BossHit")
        {
            Bear bear = other.gameObject.GetComponent<Bear>();

            if (bossDMG)
            {
                GameObject.FindObjectOfType<Bear>().jumpedOn();
                bossDMG = false;
            }
            state = State.Jump;
            rb.AddForce(Vector2.up * (jumpForce + 8), ForceMode2D.Impulse);
            
        }

        if (other.gameObject.CompareTag("Computer"))
        {
            canUse = true;
            GameObject.FindObjectOfType<Computer>().GetComponent<Computer>().e.SetActive(true);
        }

        if (other.gameObject.CompareTag("Flower"))
        {
            Destroy(other.gameObject);
            GameObject.FindObjectOfType<LevelSelector>().GetComponent<LevelSelector>().spring = true;
        }

        if (other.gameObject.CompareTag("IceCream"))
        {
            Destroy(other.gameObject);
            GameObject.FindObjectOfType<LevelSelector>().GetComponent<LevelSelector>().summer = true;
        }

        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            GameObject.FindObjectOfType<LevelSelector>().GetComponent<LevelSelector>().autumn = true;
        }

        if (other.gameObject.CompareTag("SnowGlobe"))
        {
            Destroy(other.gameObject);
            GameObject.FindObjectOfType<LevelSelector>().GetComponent<LevelSelector>().winter = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Computer"))
        {
            canUse = false;
            GameObject.FindObjectOfType<Computer>().GetComponent<Computer>().e.SetActive(false);
        }

        if (other.gameObject.CompareTag("SideWall"))
        {
            canJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            bossDMG = true;
        }
    }

    public void PlayRunningSound()
    {
        audioSource.PlayOneShot(runSound);
    }
}

