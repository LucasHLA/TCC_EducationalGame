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
        Vector2 target = new Vector2(robot.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * fixedTimeStep);
        rb.MovePosition(newPos);

        if (Vector2.Distance(robot.position, rb.position) <= attackDistance)
        {
            animator.GetComponent<IceEnemyController>().Defeated();
            GameObject.FindGameObjectWithTag("Robot").GetComponent<TankerRobot>().Damage();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
