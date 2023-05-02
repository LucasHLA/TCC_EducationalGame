using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [Header("Ghost Related")]
    [SerializeField] private float radius;
    public GameObject ghost;

    private void FixedUpdate()
    {
        GhostEnable();
    }

    private void GhostEnable()
    {
        Collider2D appearanceArea = Physics2D.OverlapCircle(transform.position, radius);

        if (appearanceArea != null)
        {
            if (appearanceArea.CompareTag("Robot"))
            {
                ghost.SetActive(true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
