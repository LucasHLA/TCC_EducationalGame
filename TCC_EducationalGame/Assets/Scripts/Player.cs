using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Basic Settings")]
    private Rigidbody2D rb;
    private Collider2D col;
    [SerializeField] private int health;
    [SerializeField] private float speed;

    [Header("State Machine")]
    private Animator anim;
    private enum State {Idle, Walk, Jump, Using};
    private State state = State.Using;
    public bool canUse = false;
    public bool usingPC = false;

    [Header("Jumping related")]
    [SerializeField] private LayerMask ground;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isJumping;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
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
        else if(!canUse && state != State.Using)
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

        if( horizontal > 0)
        {
            state = State.Walk;
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else if( horizontal < 0)
        {
            state = State.Walk;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if(horizontal == 0 && rb.velocity.y == 0f)
        {
            state = State.Idle;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && col.IsTouchingLayers(ground))
        {
                state = State.Jump;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if(rb.velocity.y > 0.01f)
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
        }

        if (other.gameObject.CompareTag("Computer"))
        {
            canUse = true;
            GameObject.FindObjectOfType<Computer>().GetComponent<Computer>().e.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Computer"))
        {
            canUse = false;
            GameObject.FindObjectOfType<Computer>().GetComponent<Computer>().e.SetActive(false);
        }
    }
}
