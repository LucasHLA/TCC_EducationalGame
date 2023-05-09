using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceEnemy : StateMachineBehaviour
{
    private Rigidbody2D rb;
    private Transform robot;

    [SerializeField] private float speed;
    [SerializeField] private float fixedTimeStep;

    [SerializeField] private float attackDistance;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        robot = GameObject.FindGameObjectWithTag("Robot").transform;
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2.MoveTowards(rb.position, robot.position, speed * fixedTimeStep);

        if (Vector2.Distance(robot.position, rb.position) <= attackDistance)
        {
            //Call the hit animator of the robot here
            Debug.Log("Attack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
