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

    [Header("Golem Area")]
    public LayerMask layer;
    public Vector3 offset;
    public float range;

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
            anim.SetTrigger("atk");
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
        Destroy(this.gameObject, 0.8f);
    }

    private void WakeUpArea()
    {
        Vector3 pos = transform.position;

        pos += transform.right * offset.x;
        pos += transform.up * offset.y;

        Collider2D area = Physics2D.OverlapCircle(pos, range, layer);
        if (area != null )
        {
            if (area.CompareTag("Robot"))
            {
                Debug.Log("Robot");
                /*anim.SetInteger("state", 1);
                StartCoroutine(Attack());*/
            }
        }
    }


    private IEnumerator ThrowSnowballCadence()
    {
        isShooting = true;
        throwCount = 0;

        while (throwCount < throwsPerCadence)
        {
            ThrowSnowball();
            throwCount++;
            yield return new WaitForSeconds(cadenceInterval);
        }

        yield return new WaitForSeconds(cooldownInterval);
        isShooting = false;
    }

    private void ThrowSnowball()
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
