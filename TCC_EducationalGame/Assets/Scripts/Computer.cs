using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [Header("Animation Related")]
    private Animator anim;
    private bool playerUsing;
    private Animator playerAnim;

    [Header("Indicators related")]
    public GameObject e;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerUsing = GameObject.FindObjectOfType<Player>().GetComponent<Player>().usingPC;
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

    }

    
    void Update()
    {
        playerUsing = GameObject.FindObjectOfType<Player>().GetComponent<Player>().usingPC;

        if (playerUsing)
        {
            anim.SetInteger("State", 1);
            playerAnim.SetInteger("State", 3);
        }
        else
        {
            anim.SetInteger("State", 0);
        }

        
    }
}
