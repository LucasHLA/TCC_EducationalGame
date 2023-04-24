using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear_Run : StateMachineBehaviour
{
    Transform player;
    public Rigidbody2D rb;

    public float speed = 1f;
    public float attackDistance = 3f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GameObject.FindObjectOfType<Bear>().GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.FindObjectOfType<Bear>().PlayerDirection();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        rb.MovePosition(newPos);

        if(Vector2.Distance(player.position, rb.position) <= attackDistance)
        {
            animator.SetTrigger("atk");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("atk");
    }
}
