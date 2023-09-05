using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationTextAnimation : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ShowText()
    {
        anim.SetInteger("show", 1);
    }
}
