using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{

    public Rigidbody2D playerRB;
    [SerializeField] private float pushForce;

    private void Start()
    {
        playerRB = GameObject.FindGameObjectWithTag("Robot").GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.transform.position.x < transform.position.x)
        {
            Debug.Log("Push");
        }
    }
}
