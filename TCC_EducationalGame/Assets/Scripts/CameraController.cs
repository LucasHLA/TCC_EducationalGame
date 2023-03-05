using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Configs")]
    [SerializeField] private float speed;
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;
    [SerializeField] private bool bound;

    [Header("Who to follow")]
    private Transform target;
    private bool changeTarget;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        changeTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().usingPC;
    }

    // Update is called once per frame
    void Update()
    {
        changeTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().usingPC;

        if (changeTarget)
        {
            target = GameObject.FindGameObjectWithTag("Robot").transform;
        }
        else if(!changeTarget)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed) + new Vector3(0, 0, -10);

            if (bound)
            {
                transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), -10);
            }
        }

    }
}
