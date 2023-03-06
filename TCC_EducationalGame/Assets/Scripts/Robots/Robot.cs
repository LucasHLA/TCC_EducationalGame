using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [Header("Basic Settings")]
    protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    protected BoxCollider2D box;

    [Header("State Machine")]
    private Animator anim;
    protected enum State { Idle, Walk, Special}
    protected State state = State.Idle;

    [Header("Moviment related")]
    [SerializeField] protected bool usingSpecial;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        anim.SetInteger("State", (int)state);
    }

    public void BaseMoviment()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal > 0)
        {
            state = State.Walk;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontal < 0)
        {
            state = State.Walk;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (horizontal == 0 && rb.velocity.y == 0f)
        {
            state = State.Idle;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int letterLayer = LayerMask.NameToLayer("letter");

        if (other.gameObject.layer == letterLayer)
        {
            GameController.instance.letterTag = other.gameObject.tag.ToString();
            Destroy(other.gameObject);
            GameController.instance.index++;
        }
    }
}
