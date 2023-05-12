using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Robot"))
        {
            GameObject.FindGameObjectWithTag("Barrier").GetComponent<Animator>().SetTrigger("up");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Robot"))
        {
            GameObject.FindGameObjectWithTag("Barrier").GetComponent<Animator>().SetTrigger("down");
        }
    }
}
