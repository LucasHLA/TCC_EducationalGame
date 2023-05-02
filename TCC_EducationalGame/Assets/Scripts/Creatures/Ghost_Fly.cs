using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Fly : StateMachineBehaviour
{
    Transform robot;
    public Rigidbody2D rb;

    public float speed = 1f;
    public float stopDistance = 3f;
    public float fixedTimeStep = 0.02f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        robot = GameObject.FindGameObjectWithTag("Robot").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Vector2 target = new Vector2(robot.position.x, robot.position.y);
        float distance = Vector2.Distance(rb.position, target);
        Debug.Log(distance);
        if (distance <= stopDistance)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * fixedTimeStep);
            rb.MovePosition(newPos);
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
