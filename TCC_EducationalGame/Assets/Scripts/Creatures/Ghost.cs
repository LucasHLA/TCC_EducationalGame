using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform robot;
    [SerializeField] private bool isFlipped;

    void Update()
    {
        RobotDirection();
    }

    public void RobotDirection()
    {
        Vector3 flip = transform.localScale;

        flip.z *= -1f;

        if (transform.position.x < robot.position.x && isFlipped)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > robot.position.x && !isFlipped)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
