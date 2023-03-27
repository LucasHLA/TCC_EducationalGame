using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hummingbird : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float animationTime;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        animationTime += Time.deltaTime;

        if(animationTime >= 0 && animationTime <= 2f)
        {
            anim.SetInteger("State", 0);
        }
        else if(animationTime >= 2.1f && animationTime <= 4f)
        {
            anim.SetInteger("State", 1);
        }
        else if(animationTime >= 4.1f && animationTime <= 6f)
        {
            anim.SetInteger("State", 2);
        }
        else if(animationTime >= 7f)
        {
            animationTime = 0f;
        }
    }
}
