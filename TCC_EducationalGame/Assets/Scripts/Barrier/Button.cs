using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator anim;
    private PolygonCollider2D pol;

    void Start()
    {
        anim = GetComponent<Animator>();
        pol = GetComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Robot") || other.gameObject.CompareTag("Player"))
        {
            anim.SetInteger("State", 1);
            GameObject.FindGameObjectWithTag("Barrier").GetComponent<Animator>().SetInteger("State", 1);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Robot") || other.gameObject.CompareTag("Player"))
        {
            anim.SetInteger("State", 0);
            GameObject.FindGameObjectWithTag("Barrier").GetComponent<Animator>().SetInteger("State", 2);
            int a = GameObject.FindGameObjectWithTag("Barrier").GetComponent<Animator>().GetInteger("State");
            if (a == 2)
            {
                GameObject.FindGameObjectWithTag("Barrier").GetComponent<Animator>().SetInteger("State", 0);
            }
        }
    }
}
