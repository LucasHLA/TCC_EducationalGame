using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGolem : MonoBehaviour
{
    [Header("Basic Settings")]
    public int health;
    public Animator anim;

    [Header("Attack Related")]
    public Transform firePoint;
    public Transform robot;
    public GameObject snowBall;
    public GameObject letterDrop;

    [Header("Shooting related")]
    [SerializeField] private bool isShooting;
    [SerializeField] private float waitingTime;
    public float throwForce;
    public int throwsPerCadence = 3;
    public float cadenceInterval = 1f;
    public float cooldownInterval = 3f;

    private int throwCount = 0;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Defeated();
        }

        if(anim.GetInteger("state") == 1)
        {
            StartCoroutine(Attack());
        }
    }

    public void Damage()
    {
        if (health > 0)
        {
            anim.SetTrigger("hurt");
            health--;
        }
    }

    public void Defeated()
    {
        anim.SetTrigger("defeated");
        GameObject.FindObjectOfType<BossSceneLogic>().isDestroyed = true;
        Destroy(this.gameObject, 0.8f);
    }

    private IEnumerator ThrowSnowballCadence()
    {
        isShooting = true;
        throwCount = 0;
        
        while (throwCount < throwsPerCadence)
        {
            anim.SetTrigger("atk");
            throwCount++;
            yield return new WaitForSeconds(cadenceInterval);
        }

        yield return new WaitForSeconds(cooldownInterval);
        isShooting = false;
    }

    public void ThrowSnowball()
    {
        GameObject newSnowball = Instantiate(snowBall, firePoint.position, Quaternion.identity);
        Vector2 direction = (robot.position - firePoint.position).normalized;
        newSnowball.GetComponent<Rigidbody2D>().AddForce(direction * throwForce, ForceMode2D.Impulse);
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(waitingTime);
        if (!isShooting)
        {
            StartCoroutine(ThrowSnowballCadence());
        }
    }
}
