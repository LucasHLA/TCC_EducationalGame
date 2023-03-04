using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [Header("Animation Related")]
    private Animator anim;
    private bool playerUsing;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerUsing = GameObject.FindObjectOfType<Player>().GetComponent<Player>().usingPC;

    }

    
    void Update()
    {
        playerUsing = GameObject.FindObjectOfType<Player>().GetComponent<Player>().usingPC;

        if (playerUsing)
        {
            anim.SetInteger("State", 1);
            
        }
        else
        {
            anim.SetInteger("State", 0);
        }

        
    }
}
