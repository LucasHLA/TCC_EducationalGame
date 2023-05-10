using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceEnemyController : MonoBehaviour
{
    private Animator anim;

    public int health;
    void Start()
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

    public void Defeated()
    {
        anim.SetTrigger("hurt");
        StartCoroutine(DefeatedRoutine());
    }

    private IEnumerator DefeatedRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
