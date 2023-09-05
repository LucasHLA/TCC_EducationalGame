using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float stoppingDistance;

    private Rigidbody2D rb;
    private bool isMoving = true;
    private Animator anim;
    public GameObject textObject;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        anim = GetComponent<Animator>();

    }
    void Update()
    {
        if (isMoving)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * speed;
            anim.SetInteger("state", 1);
            if (Vector3.Distance(transform.position, target.position) < stoppingDistance)
            {
                anim.SetInteger("state", 0);;
                rb.velocity = Vector3.zero;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            textObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("TeleportInfo"))
        {
            GameObject.FindObjectOfType<SceneController>().ChangeScene();
        }
    }
}
