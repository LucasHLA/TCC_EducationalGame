using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGolem : MonoBehaviour
{
    [Header("Basic Settings")]
    public int health;
    private Animator anim;

    [Header("Attack Related")]
    public Transform firePoint;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(health <= 0)
        {
            Defeated();
        }
    }

    public void Damage()
    {
        if(health > 0)
        {
            anim.SetTrigger("hurt");
            health--; 
        }
    }

    public void Defeated()
    {
        anim.SetTrigger("defeated");
        Destroy(this.gameObject, 0.8f);
    }
}
