using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlocks : MonoBehaviour
{
    private Animator anim;
    public int health;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(health <= 3 && health > 0)
        {
            anim.SetInteger("state", 1);
        }

        if(health <= 0)
        {
            anim.SetInteger("state", 2);
            StartCoroutine(getDestroyed());
        }
    }

    private IEnumerator getDestroyed()
    {
        yield return new WaitForSeconds(0.17f);
        Destroy(this.gameObject);
    }
}
