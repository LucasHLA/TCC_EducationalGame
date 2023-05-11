using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterBoss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Robot"))
        {
            GameObject.FindGameObjectWithTag("SnowGolem").GetComponent<SnowGolem>().anim.SetInteger("state", 1);
        }
    }
}
