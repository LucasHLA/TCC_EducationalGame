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
    public Transform robot;
    public GameObject snowBall;

    [Header("Golem Area")]
    public LayerMask layer;
    public Vector3 offset;
    public float range;

    [Header("Shooting related")]
    [SerializeField] private bool isShooting;
    public float throwForce;
    public int maxThrows = 3;
    public float throwInterval = 2f;

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
    }

    private void FixedUpdate()
    {
        WakeUpArea();
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
        float distance = Vector2.Distance(robot.position, transform.position);
        if (area != null)
        {
            if (area.CompareTag("Robot"))
            {
                Debug.Log(distance);
                if (distance > 10.9)
                {
                    anim.SetInteger("state", 1);

                    if (!isShooting)
                    {
                        StartCoroutine(ThrowSnowballs());
                    }
                }
            }
        }
    }

    private IEnumerator ThrowSnowballs()
    {
        isShooting = true;
        throwCount = 0;

        while (throwCount < maxThrows)
        {
            ThrowSnowball();
            throwCount++;
            yield return new WaitForSeconds(throwInterval);
        }

        isShooting = false;
    }

    private void ThrowSnowball()
    {
        GameObject newSnowball = Instantiate(snowBall, firePoint.position, Quaternion.identity);
        Vector2 direction = (robot.position - firePoint.position).normalized;
        newSnowball.GetComponent<Rigidbody2D>().AddForce(direction * throwForce, ForceMode2D.Impulse);
    }

    private void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos += transform.right * offset.x;
        pos += transform.up * offset.y;

        Gizmos.DrawWireSphere(pos, range);
    }
}
